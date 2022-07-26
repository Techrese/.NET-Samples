import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Hero } from "src/models/hero";
import { catchError, Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})

export class heroService {


    private heroesUrl = "http://localhost:4200/api/heroes";

    httpOptions = {
        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
      };

    constructor (private http: HttpClient) {
        
    }


    getHeroes() {
    
    }

    addHero(hero: Hero): Observable<Hero> {
        return this.http.post<Hero>(this.heroesUrl, hero, this.httpOptions);
       
    }

    updateHero(hero: Hero) {

    }

}