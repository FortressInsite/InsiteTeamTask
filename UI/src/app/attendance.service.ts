import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Attendance } from "./attendance";
import { Game } from "./game";
import { Member } from "./member";
import { Season } from "./season";
import { Ticket } from "./ticket";

@Injectable({
  providedIn: "root",
})
export class AttendanceService {
  private apiUrl = "https://localhost:5001/api";
  constructor(private http: HttpClient) {}

  getAttendance(productCode: string, seasonId: number, gameNumber: number) {
    return this.http.get<Attendance[]>(
      `${this.apiUrl}/attendance/${productCode}/${seasonId}/${gameNumber}`
    );
  }

  getAllMembers() {
    return this.http.get<Member[]>(`${this.apiUrl}/attendance/members`);
  }

  getAllTickets() {
    return this.http.get<Ticket[]>(`${this.apiUrl}/attendance/tickets`);
  }

  getAllGames() {
    return this.http.get<Game[]>(`${this.apiUrl}/attendance/games`);
  }

  getAllSeasons() {
    return this.http.get<Season[]>(`${this.apiUrl}/attendance/seasons`);
  }

  getAllProductCodes() {
    return this.http.get<string[]>(`${this.apiUrl}/attendance/productCodes`);
  }
}
