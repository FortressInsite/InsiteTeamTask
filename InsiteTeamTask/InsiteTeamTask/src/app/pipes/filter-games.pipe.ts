import { Pipe, PipeTransform } from '@angular/core';
import _ from "lodash";

@Pipe({
  name: 'filterGames'
})
export class FilterGamesPipe implements PipeTransform {

  transform(value: string, keyName: string, seasonId: any,): string {
    return _.filter(value, function (o) {
      return o[keyName] === +seasonId;
    });

  }
}
