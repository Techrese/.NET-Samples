import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Hero } from "src/models/hero";
import { catchError, Observable, retry } from "rxjs";
import { observableToBeFn } from "rxjs/internal/testing/TestScheduler";

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

    getHeroes(): Observable<Hero[]>  {
        return this.http.get<Hero[]>(this.heroesUrl);
    }

    getHero(id: number): Observable<Hero> {
        const url = `${this.heroesUrl}/${id}`;
        return this.http.get<Hero>(url);
    }

    addHero(hero: Hero): Observable<Hero> {        
        return this.http.post<Hero>(this.heroesUrl, hero, this.httpOptions);
       
    }

    updateHero(hero: Hero): Observable<Hero> {
        return this.http.put<Hero>(this.heroesUrl, hero, this.httpOptions);
    }

    deleteHero(id: number): Observable<Hero> {
        const url = `${this.heroesUrl}/${id}`;
        return this.http.delete<Hero>(url, this.httpOptions);
    }

}