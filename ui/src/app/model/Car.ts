import { Brand } from "./Brand";

export interface Car {
  id: number;
  name: string;
  createdDate: Date;
  brand: Brand;
}
