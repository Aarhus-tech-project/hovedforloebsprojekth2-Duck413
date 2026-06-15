//Edit collection
/*TEST CODE, TO BE DELETED
export function load({ params }: { params: { id: string } }) {
    return { 
        id: params.id,
        collection: {
            collectionName: 'Test Collection',
            collectionDescription: 'Test Description'
        }
    };
}*/

/*ACTUAL CODE TO BE USED*/
const BASE = 'http://localhost:5215/api';

export async function load({ params }: { params: { id: string } }) {
    const res = await fetch(`${BASE}/Collection/${params.id}`);
    const collection = await res.json();
    return { id: params.id, collection };
}