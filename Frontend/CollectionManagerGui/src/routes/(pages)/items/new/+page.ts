//Create item page
export function load({ url }: { url: URL }) {
    const collectionId = url.searchParams.get('collectionId') ?? '';
    const from = url.searchParams.get('from') ?? '/collections';
    return { collectionId, from };
}