$('#inputParser').change(function () {
    var text = $('#inputParser').val();
    var élémentsCriteres = new Array();
    // split le text, à partir de l'indicateur de order liste.
    // les éléments qui se distingerons, sont dinstinctivement, l'énoncé suivie des critères
    var élémentsCritereMix = $(this).val().split(/[0-9]+\. /g);
    console.log(élémentsCritereMix);
    // les critères, pour le premier formatage, sont indiqué par un disc noire indiquant un élément
    // d'une liste non ordonné. l'élément premier qui sera extirpé est l'énoncé, ses suivantes sont ses critères.
    // pour le deuxième, il en revient qu'en enregistrant en pdf les disc n'appaisse plus et donc un parsing additionnelle
    // doit être fait.
    var disc = //;
    if (disc.test(text)) {
        // formatage du premier type
        élémentsCritereMix.forEach(function (element, index) {
            if (element == "" || !/[a-z]/i.test(element)) {
            } else {
                var critereMachingDot = element.split(//g).map(function (str) {
                    var temppp = trimer(str);
                    return temppp;
                }).filter(e => e != "");
                élémentsCriteres.push(critereMachingDot);
            }
        });
    }
    // formatage du deuxième type
    else {
        élémentsCritereMix.forEach(function (element, index) {
            if (element == "" || !/[a-z]/i.test(element)) {
            } else {
                // je fais supposition que toutes les phrases déterminent un élément un les critères
                var critereMachingDot = element.split('.').map(function (str) {
                    var temppp = trimer(str);
                    return temppp;
                }).filter(e => e != "");
                élémentsCriteres.push(critereMachingDot);
            }
        });
    }
    // afficher à la console pour vérifier son éta
    console.log(élémentsCriteres);
    toTable();
});

function trimer(str) {
    return str.replace(/↵|\n/g, " ").trim();
};

function toTable() {
    var table = $('#tableCompetence');
    table.empty();
    élémentsCriteres.forEach((CompetenceArray) => {
        var newrow = '<tr><th scope="row">';
        newrow += '<div class="input-group input-group-sm mb-3">' +
            '<input type="text" class="form-control" value="' + CompetenceArray[0]  + '">' +
                    '</div>' + '</th><td>';
        CompetenceArray.forEach((item, index) => {
            if (index != 0) {
                newrow += '<div class="input-group input-group-sm mb-3">' +
                    '<textarea class="form-control">' + item +'</textarea>' +
                    '</div>';
            }
        });
        newrow += '</td></tr>'
        table.append(newrow);
    });
};