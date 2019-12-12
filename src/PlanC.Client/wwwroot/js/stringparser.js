var competenceFromtable;
var élémentsCriteres = new Array();

$('#inputParser').change(function () {
    var text = $('#inputParser').val();
    élémentsCriteres = new Array();
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
    // instancie un nouvel object contenant tous les nouvelles éléments de compétences
    // ils seront des tables contenant les critères qui seront afficher chez l'utilisateur
    // lors du changement dans la table cahque enregistrement seront sauvegardé
    // dans l'objet approprié.
    competenceFromtable = new Object();
    // indication du nombre d'élement contenant dans l'objet
    élémentsCriteres.forEach((CompetenceArray, findex) => {
        // ajoute tous les critères dans l'objet agissant comme dictionnaire.
        competenceFromtable[findex] = CompetenceArray;
        competenceFromtable[findex]['index'] = findex; // initialisation de l'index dans la liste existante
        // premier élément contient l'énoncé
        var newrow = '<tr id="sorted_' + findex +'"><th scope="row">';
        newrow += '<div class="input-group input-group-sm mb-3">' +
            '<input type="text" class="form-control" ' +
            'value="' + CompetenceArray[0] + '">' +
            '</div>' + '</th><td>';
        // itération pour trouver tous les critère d'évaluation pour les afficher
        CompetenceArray.forEach((item, index) => {
            if (index != 0) {
                newrow += '<div class="input-group input-group-sm mb-3">' +
                    '<textarea class="form-control" ' +
                    'name="' + competenceFromtable[findex][index] + '">' + item + '</textarea>' +
                    '</div>';
            }
        });
        newrow += '</td></tr>'
        table.append(newrow); // ajoute à la table à l'intérieur du DOM
    });
    console.log(competenceFromtable); // log l'objet

    // ready up le sortable array
    console.log("making sortable");
    $('#tableCompetence').sortable({
        forcePlaceholderSize: true,
        placeholder: "ui-state-highlight",
        revert: true
    });
};

function serialize() {
    var table = $('#tableCompetence').sortable('toArray').toString();
    $("#sorted_")
    console.log(table);
}