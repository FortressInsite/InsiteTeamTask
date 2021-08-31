export interface Product {
  id: string;
  seasonId: number;
  validFrom: Date;
  type: "Ticket" | "Member";
  gameId: number;
}
