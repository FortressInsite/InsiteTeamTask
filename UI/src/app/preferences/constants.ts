import { HttpHeaders } from "@angular/common/http";

export class Constants {
  public static httpOptions = {
    headers: new HttpHeaders({ "Content-Type": "application/json" }),
  };

}
