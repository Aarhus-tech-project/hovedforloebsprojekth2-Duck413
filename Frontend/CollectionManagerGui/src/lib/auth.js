// @ts-nocheck
let token = null;

export function setToken(t) {
  token = t;
  localStorage.setItem('token', t);
}

export function getToken() {
  return token ?? localStorage.getItem('token');
}