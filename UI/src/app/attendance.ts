export interface Attendance {
  attendanceType: "SeasonTicket" | "GameTicket";
  memberId: number;
  barcode: string;
}
