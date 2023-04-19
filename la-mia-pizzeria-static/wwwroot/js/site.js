


const getPizze = () => axios.get('/api/PizzaApi/GetPizzas/?name=');

const renderPizze = pizze => {
    const pizzebody = document.querySelector('#pizze');
    pizzebody.innerHTML = pizze.map(pizzeComponent).join('');
};

console.log(getPizze);

const pizzeComponent = pizza => `    
< div class="col" >
    <div class="card">
        <img src="${pizza.ImgUrl}" class="card-img-top" alt="${pizza.Name}">
        <div class="card-body">
           <h5 class="card-title">${pizza.Name}</h5>
           <p class="card-text">${pizza.Description}</p>
           <span> <p>${pizza.Prezzo} €</p> </span>            
        </div>
    </div >
 </div >
  `;


