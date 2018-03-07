import { Component, OnInit } from '@angular/core';

@Component({    
    template: `<h1>Summary</h1>
    <chart type="pie" [data]="data"></chart>
    `
})
export class CounterComponent implements OnInit {
    ngOnInit() { }

    data = {
        labels: ['BMW', 'Audi', 'Mazda'],
        datasets: [
            { 
                data: [5, 3, 1],
                backgroundColor: [
                    "#ff6384",
                    "#36a2eb",
                    "#ffce56"
                ]
            }
        ]
    }
}
