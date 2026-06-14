//View item
export function load({ params }: { params: { id: string, itemId: string } }) {
    return { 
        collectionId: params.id,
        itemId: params.itemId
    };
}