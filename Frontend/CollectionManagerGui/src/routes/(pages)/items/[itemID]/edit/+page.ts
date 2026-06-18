//Edit item
export const ssr = false;

import { getToken } from '$lib/auth.js';
import { BASE } from '$lib/config.js'; 

export async function load({ params }: { params: { itemID: string } }) {
    const token = getToken();
    const headers = { 'Authorization': `Bearer ${token}` };

    const res = await fetch(`${BASE}/Item/${params.itemID}`, { headers });
    const item = await res.json();

    return { 
        itemId: params.itemID, 
        item, 
        collectionId: item.collectionId ?? null 
    };
}