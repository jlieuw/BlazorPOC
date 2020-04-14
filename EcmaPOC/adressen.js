import './adresinfo.js';

const adressenUrl = "https://backendvalidaties.azurewebsites.net/adressen";

window.addEventListener('load', () => {
    fetchAdressen();
});

async function fetchAdressen() {
    const res = await fetch(adressenUrl);
    const json = await res.json();

    let maindiv = document.getElementById("main");
    json.forEach(adres => {
        let el = document.createElement('adres-info');
        el.adres = adres;
        maindiv.appendChild(el);
    });
}