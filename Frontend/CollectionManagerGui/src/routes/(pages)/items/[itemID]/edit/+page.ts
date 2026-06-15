//Edit item
/*ACTUAL CODE TO BE USED*/
const BASE = 'http://localhost:5215/api';

export async function load({ params }: { params: { id: string, itemId: string } }) {
    const res = await fetch(`${BASE}/Item/${params.itemId}`);
    const item = await res.json();
    return { collectionId: params.id, itemId: params.itemId, item };
}

/*TEST CODE, DELETE
export function load({ params }: { params: { itemID: string } }) {
    return {
        itemId: params.itemID,
        item: {
            itemName: 'Test Item',
            itemDescription: 'Test Description',
            itemType: 'Test Type',
            itemValue: 0,
            itemCount: 0
        }
    };
}*/