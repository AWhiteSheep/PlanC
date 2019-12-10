/**
 *
 * Yan Ha Routhier - Chevrier
 * Page - blazor
 *
 * 
 * weather client
 * Uses
 * jQuery Cookie Plugin v1.4.1
 * https://github.com/carhartl/jquery-cookie
 * Uses
 * Weatherstack
 * http://api.weatherstack.com
 * Uses
 * Moment.js
 * https://momentjs.com
 */
var weatherData = $.cookie('weather');
if (weatherData == undefined) {
    console.log("no weather defined in cookie calling api...")
    $.ajax({
        url: 'http://api.weatherstack.com/current',
        data: {
            access_key: 'c566ca8f782b91cfffc4f0ca0b0bf865',
            query: 'gatineau'
        },
        dataType: 'json',
        success: function (apiResponse) {
            var serializedWeather = JSON.stringify(apiResponse);
            console.log(`Current temperature in ${serializedWeather}  ℃`);
            $.cookie('weather', serializedWeather, { expires: 1 });
            weatherControlUI();
        }
    });
} else {
    weatherControlUI();
}

function weatherControlUI() {
    // chercher le weater cookie
    var serializedWeather = $.cookie('weather');
    weatherObject = JSON.parse(serializedWeather);
    console.log(weatherObject); // affiche le debug sur la console
    // endroit ou la température a été prise
    var locationWeather = weatherObject.location;
    // top row
    var topRow = document.createElement("div");
    topRow.classList.add("d-flex");
    // température
    var current = weatherObject.current
    var usefulInfo = {};
    usefulInfo.Ressenti = current.feelslike;
    usefulInfo.Humidité = current.humidity;
    usefulInfo.Témpérature = (current.temperature);
    usefulInfo['Vitesse du vent'] = (current.wind_speed);
    var table = document.createElement("table");
    for (const property in usefulInfo) {
        var arrayLigne = document.createElement("tr");
        var valueName = document.createElement("td");
        var valueProperty = document.createElement("td");
        // ajoute au td la propriété
        valueName.append(property);
        // ajoute sa valeur
        valueProperty.append(usefulInfo[property]);
        // entre dans la ligne
        arrayLigne.appendChild(valueName);
        arrayLigne.appendChild(valueProperty);
        // ajout à la table
        table.appendChild(arrayLigne);
    }    
    // date
    var weatherLocaltime = new Date(locationWeather.localtime);
    moment.locale('fr');
    newdate = moment(weatherLocaltime).format('ll');
    var localTime = document.createElement("div");
    localTime.classList.add("h4");
    localTime.classList.add("pt-1");
    localTime.append(newdate);
    // création de l'icon de la température d'aujourd'hui
    var weatherIconUrl = weatherObject.current.weather_icons[0];
    var weatherIconElment = document.createElement("img");
    weatherIconElment.style.width = "auto";
    weatherIconElment.style.height = "100%";
    weatherIconElment.classList.add("p-1");
    weatherIconElment.classList.add("pr-2");
    weatherIconElment.src = weatherIconUrl;
    // ajoute au wrapper
    topRow.appendChild(weatherIconElment);
    topRow.append(table);
    document.getElementById("weatherOfDay").appendChild(topRow);
    // ajout du local time
    var locationName = locationWeather.name;
    console.log(locationName);
}

// rend le temps d'attente accessible à tout les objets
var timeOut;

// the weather calendar control-center
class Item {
    constructor(content, backgroundColor, desiredClass) {
        this.$element = $(document.createElement("h4"));
        this.content = content;
        this.$element.addClass(desiredClass);
        this.$element.addClass("card");
        this.$element.addClass("display-none");
        this.$element.css("background-color", backgroundColor);
        this.$element.append(content);
        this.isMoving = false;
    }
}


// class menu
class Menu {
    constructor(menu) {
        this.$element = $(menu);
        this.size = 0;
        this.items = new Array();
        this.isMoving = false;
        this.hasMoved = false;
        this.status = "closed";
    }

    add(item) {
        var menu = this.items;
        menu[this.size] = item;
        this.size++;
        this.$element.append(item.$element);
    }
    open() {
        this.status = "open";
        var menu = this.items;
        menu.forEach(function (item, index, menu) {
            menu[index].$element.removeClass("display-none");
        });
    }
    close() {
        this.status = "closed";
        var menu = this.items;
        menu.forEach(function (item, index, menu) {
            menu[index].$element.addClass("display-none");
        });
    }
}

// nouveau menu opener
var menu = new Menu("#calendarMenu");
// set le langage et la date du client
var dateMoment = moment().format('LLLL');
// ajout au menu
var calendar = new Item(dateMoment, "#fff", "calendarWheater");
menu.add(calendar);

menu.$element.on("click", function(){
    if (menu.status == "open") {
        menu.close();
    } else {
        menu.open();
    }
});