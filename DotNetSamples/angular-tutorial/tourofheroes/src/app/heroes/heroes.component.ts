import { Component, OnInit } from '@angular/core';
import { Hero } from 'src/models/hero';
import { heroService } from 'src/services/hero.service';


@Component({
  selector: 'app-heroes',
  templateUrl: './heroes.component.html',
  styleUrls: ['./heroes.component.css']
})
export class HeroesComponent implements OnInit {
  heroes: Hero[] = [];
  title = "My Heroes";

  constructor(private heroService: heroService) { }

  ngOnInit(): void {
    this.getHeroes();
  }

  getHeroes() {
    this.heroService.getHeroes().subscribe(heroes => this.heroes = heroes);
    console.log(this.heroes);
  }

  delete(hero: Hero) {
    this.heroService.deleteHero(hero.id);
  }

}
