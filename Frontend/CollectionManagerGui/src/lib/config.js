// src/lib/config.js
const isLocalhost = typeof window !== 'undefined' && window.location.hostname === 'localhost';

export const BASE = isLocalhost
  ? 'https://localhost:44366/api'
  : 'http://api.gr02.prog.skylab.academy/api';