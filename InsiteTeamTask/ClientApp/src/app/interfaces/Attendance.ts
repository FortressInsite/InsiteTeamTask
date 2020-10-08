export interface Attendance {
  members: Members[];
  tickets: Tickets[];
}

interface Members {
  id: string;
  productId: string;
}

interface Tickets {
  barcode: string;
  productId: string;
}
