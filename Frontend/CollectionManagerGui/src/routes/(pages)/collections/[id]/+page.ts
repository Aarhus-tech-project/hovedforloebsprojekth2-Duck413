//View 1 collection
export function load({ params }: { params: { id: string } }) {
  return { id: params.id };
}