//View 1 collection
const BASE = 'http://localhost:5215/api';

export async function load({ params }: { params: { id: string } }) {
    const [collectionRes, itemsRes] = await Promise.all([
        fetch(`${BASE}/Collection/${params.id}`),
        fetch(`${BASE}/Item/collection/${params.id}`)
    ]);
    const collection = await collectionRes.json();
    const items = await itemsRes.json();
    return { id: params.id, collection, items };
}