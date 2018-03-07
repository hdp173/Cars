import { Component, OnInit } from '@angular/core';

@Component({    
    template: `<h1>Summmmmary</h1>
    <chart type="pie" [data]="data"></chart>
    `
})
export class CounterComponent implements OnInit {
    ngOnInit() { }

    data = {
        labels: ['BMW', 'Audi', 'Mazda', 'Opel', 'Toyota'],
        datasets: [
            { 
                data: [5, 3, 1, 4, 10],
                backgroundColor: [
                    "#ff6384",
                    "#36a2eb",
                    "#ffce56",
                    '#8cc442',
                    '#c13a8d'
                ]
            }
        ]
    }
}
