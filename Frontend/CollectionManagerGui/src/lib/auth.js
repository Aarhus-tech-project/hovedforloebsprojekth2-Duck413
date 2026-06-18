// @ts-nocheck
let token = null;

export function setToken(t) {
  token = t;
  if (typeof window !== 'undefined') {
    localStorage.setItem('token', t);
  }
}

export function getToken() {
  if (typeof window === 'undefined') return null;
  return token ?? localStorage.getItem('token');
}

export function getDisplayName() {
  const t = getToken();
  if (!t) return null;
  const payload = JSON.parse(atob(t.split('.')[1]));
  return payload.displayName ?? payload.name ?? payload.unique_name ?? null;
}