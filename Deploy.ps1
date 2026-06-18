$ErrorActionPreference = "Stop"

$Server = "192.168.102.5"
$User = "anne"

$BackendPath = ".\Backend\CollectionManagerApi"
$FrontendPath = ".\Frontend\CollectionManagerGUI"

Write-Host "Cleaning local deploy output..."
Remove-Item -Recurse -Force ".\deploy-output" -ErrorAction SilentlyContinue
New-Item -ItemType Directory -Force ".\deploy-output\backend" | Out-Null

Write-Host "Publishing backend..."
dotnet publish "$BackendPath" -c Release -o ".\deploy-output\backend"
if ($LASTEXITCODE -ne 0) { throw "Backend publish failed." }

Write-Host "Building frontend..."
Push-Location $FrontendPath
bun install
if ($LASTEXITCODE -ne 0) { throw "npm install failed." }

bun run build
if ($LASTEXITCODE -ne 0) { throw "Frontend build failed." }
Pop-Location

Write-Host "Preparing remote folders..."
ssh "${User}@${Server}" "rm -rf /tmp/gr02-deploy && mkdir -p /tmp/gr02-deploy/backend /tmp/gr02-deploy/frontend"
if ($LASTEXITCODE -ne 0) { throw "Could not prepare remote folders." }

Write-Host "Copying backend to server..."
scp -r ".\deploy-output\backend\*" "${User}@${Server}:/tmp/gr02-deploy/backend/"
if ($LASTEXITCODE -ne 0) { throw "Backend copy failed." }

Write-Host "Copying frontend to server..."
scp -r "$FrontendPath\build\*" "${User}@${Server}:/tmp/gr02-deploy/frontend/"
if ($LASTEXITCODE -ne 0) { throw "Frontend copy failed." }

Write-Host "Running server deploy script..."
ssh -t "${User}@${Server}" "sudo /usr/local/bin/deploy-gr02.sh"
if ($LASTEXITCODE -ne 0) { throw "Remote deploy script failed." }

Write-Host "Deployment finished."