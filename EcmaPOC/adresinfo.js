class AdresInfo extends HTMLElement {
    constructor() {
        super();

        let shadow = this.attachShadow({
            mode: 'open'
        });

        var style = document.createElement('style');
        style.textContent = `strong{color:red}
                            .clearfix::after {
                                content: "";
                                clear: both;
                                display: table;
                            }`

        shadow.appendChild(style);
    }

    set adres(adres) {
        let div = document.createElement('div');
        div.style = 'width:400px;overflow:auto;margin:25px;';
        div.className = 'clearfix';
        for (let regel in adres) {
            div.innerHTML += `               
                    <div style='width:200px;float:left;'>
                        <strong>${regel}</strong>
                    </div>
                    <div style='width:200px;float:left;'>
                        ${adres[regel]}&nbsp;
                    </div>
            `;
        }
        this.shadowRoot.appendChild(div);
    }
}

customElements.define('adres-info', AdresInfo);