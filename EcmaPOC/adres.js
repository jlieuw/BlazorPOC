class AdresForm {

    init() {
        this.render();
    }

    async SendData(datajson) {
        const rawResponse = await fetch('https://backendvalidaties.azurewebsites.net/adres', {
            method: 'POST',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            body: datajson
        });
        const content = await rawResponse.json();
        console.log(content);
        if (content.status === 400) {
            this.handleValidationErrors(content.detail);
        } else if (!content.status) {
            console.log('succes!');
        }

    }

    handleValidationErrors(msgs) {
        let errorsel = document.getElementById('errors');
        errorsel.innerHTML = msgs;
        errorsel.classList.remove('hide');
    }

    handleFormSubmit = (e) => {
        e.preventDefault();

        let elements = document.forms[0].elements;
        let data = this.extractFormData(elements);
        let datajson = JSON.stringify(data);
        this.SendData(datajson);
    }

    //https://www.learnwithjason.dev/blog/get-form-values-as-json/
    extractFormData = elements => [].reduce.call(elements, (data, element) => {
        if (this.isValidElement(element)) {
            if (this.isNumber(element)) {
                data[element.name] = parseInt(element.value);
            } else {
                data[element.name] = element.value;
            }
        }
        return data;
    }, {})

    isNumber = element => {
        return element.type === 'number';
    }

    isValidElement = element => {
        return element.name;
    }

    render() {
        document.getElementById('Subscribe').addEventListener('click', this.handleFormSubmit);
    }
}


let adresForm = new AdresForm();
adresForm.init();