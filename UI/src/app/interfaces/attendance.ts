import { AttendanceType } from "../enums/attendance-type.enum";

export interface Attendance {
    attendanceType?: AttendanceType;
  
    memberId?: number;

    barcode?: string;

    game?: string;

    season?: string;
  }
  