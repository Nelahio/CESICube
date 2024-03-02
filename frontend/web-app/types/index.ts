export type PagedResult<T> = {
  results: T[];
  pageCount: number;
  totalCount: number;
};

export type Enchere = {
  reservePrice: number;
  seller: string;
  winner?: string;
  soldAmount: number;
  currentHighBid: number;
  createdAt: string;
  updatedAt: string;
  auctionEnd: string;
  statut: string;
  make: string;
  productName: string;
  year: number;
  color: string;
  size: number;
  comments: string;
  imageUrl: string;
  id: string;
};
