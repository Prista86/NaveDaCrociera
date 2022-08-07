//function prenota(id, nomeevento, locale, posti, annullato) {
//    var body = {};
//    body.Id = id;
//    body.NomeEvento = nomeevento;
//    body.Locale = locale;
//    body.Posti = posti;
//    body.Annullato = annullato;
//    body.PostiPre = $("#posti").val();                
//    $.ajax({
//        method: "POST",
//        url: "/api/API/PrenotaPosti",
//        contentType: "application/json; charset=utf-8",
//        data: JSON.stringify(body),
//        dataType: "json",
//        success: function (data, status) {
//            console.log(body);
//            console.log(data);
//            console.log(status);
//            this.always();            
//        },
//        error: function (error, status) {
//            console.log(body);
//            console.log(error);
//            console.log(status);
//            this.always();
//        },
//        always: function () {
//            window.location = window.location;
//        }
//    });    
//};

function prenota(id, nomeevento, locale, posti, annullato) {
    Posti = document.createElement("p");
    Posti.style.textAlign = "center";
    Posti.innerText = 'Inserisci il numero dei posti che vuoi riservare per lo spettacolo';
    document.getElementById("modal-body").appendChild(Posti);
    postiTextArea = document.createElement("input");
    Posti.appendChild(postiTextArea);

    OKbutton = document.createElement("button");
    OKbutton.innerText = "OK";
    OKbutton.id = "modalOKButton";
    OKbutton.classList.add("btn");
    OKbutton.classList.add("btn-success");
    OKbutton.onclick = function () {
        var body = {};
        body.Id = id;
        body.NomeEvento = nomeevento;
        body.Locale = locale;
        body.Posti = posti;
        body.Annullato = annullato;
        body.PostiPre = postiTextArea.value;
        if (body.Annullato == '1') {
            alert('Lo Spettacolo è stato annullato non è possibile visionarlo.');
            //body.Posti = 1000000;
            hideModal();
        }
        else if (body.PostiPre > body.Posti) {
            alert('Non è possibile prenotare così tanti posti, non sono tutti disponibili.');
            hideModal();
        }
        else {
            $.ajax({
                method: "POST",
                url: "/api/API/PrenotaPosti",
                contentType: "application/json; charset=utf-8",
                data: JSON.stringify(body),
                dataType: "json",
                success: function (data, status) {
                    console.log(body);
                    console.log(data);
                    console.log(status);
                    this.always();
                    window.location = window.location;
                },
                error: function (error, status) {
                    console.log(body);
                    console.log(error);
                    console.log(status);
                    this.always();
                },
                always: function () {
                    $.ajax({
                        method: "POST",
                        url: "/api/API/InsertPrenotazioniSpettacoli",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify(body),
                        dataType: "json",
                        success: function (data, status) {
                            console.log(body);
                            console.log(data);
                            console.log(status);
                            this.always();
                        },
                        error: function (error, status) {
                            console.log(body);
                            console.log(error);
                            console.log(status);
                            this.always();
                        },
                        always: function () {
                            window.location = window.location;
                        }
                    });   
                }
            });

        }
    }
    $(".modal-footer").append(OKbutton);
    CancelButton = document.createElement("button");
    CancelButton.innerText = "Cancel";
    CancelButton.id = "modalCancelButton";
    CancelButton.classList.add("btn");
    CancelButton.classList.add("btn-danger");
    CancelButton.onclick = function () {
        hideModal();
    }
    $(".modal-footer").append(CancelButton);
    document.getElementById("modal").style.display = "block";
};

function hideModal() {
    document.getElementById("modal-header").innerText = "";
    $(".modal-body").empty();
    $(".modal-footer").empty();
    document.getElementById("modal").style.display = "none";
}