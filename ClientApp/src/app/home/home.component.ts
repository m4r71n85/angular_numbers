import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  numbers: number[] = [];
  sum: number = null;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
    this.getStoredNumbers();
  }

  public generateNumber() {
    this.http.get<number>(this.baseUrl + 'api/Numbers/GetRandom').subscribe(result => {
      this.numbers.push(result);
      this.sum = null;
    }, error => console.error(error));
  }

  private getStoredNumbers() {
    this.http.get<number[]>(this.baseUrl + 'api/Numbers/GetStored').subscribe(result => {
      if (result) {
        this.numbers = result;
      }
      console.log(result);
    }, error => console.error(error));
  }

  public clearNumbers() {
    this.http.get<number[]>(this.baseUrl + 'api/Numbers/ClearNumbers').subscribe(result => {
      this.numbers = [];
      this.sum = null;
      console.log(result);
    }, error => console.error(error));
  }

  public sumNumbers() {
    this.http.get<number>(this.baseUrl + 'api/Numbers/GetSum').subscribe(result => {
      this.sum = result;
    }, error => console.error(error));
  }
}
