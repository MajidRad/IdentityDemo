import { Car } from "./Car";

export interface Brand {
  id: number;
  name: string;
  cars: Car[];
}

export enum OrderBy {
  price = "price",
  priceDesc = "priceDesc",
  name = "name",
}
export interface BrandParams {
  orderBy?: OrderBy;
  searchTerm?: string;
  pageNumber: number;
  pageSize: number;
}
