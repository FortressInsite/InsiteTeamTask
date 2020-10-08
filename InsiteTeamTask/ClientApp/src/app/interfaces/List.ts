export interface Product {
  id: string;
  seasonId: number;
  gameId: string;
  validFrom: Date;
  type: number;
}

export interface Game {
  id: number;
  description: string;
  seasonId: number;
}

export interface Season {
  id: number;
}
