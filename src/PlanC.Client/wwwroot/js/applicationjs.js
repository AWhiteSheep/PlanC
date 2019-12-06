// main js for the blazor application

// god bless stackoverflow
// https://stackoverflow.com/questions/57366355/how-do-i-use-blazor-server-side-inside-a-razor-component-library-using-areas
Blazor.start({
    configureSignalR: function (builder) {
        builder.configureLogging("information"); // LogLevel.Information
        builder.withUrl("/_blazor");
        builder.withAutomaticReconnect();
    }
});


window.showModal = (arg) => {
    $(arg).modal('toggle');
}

// suite au render de blazor lancer les utilitaires
// demande de scripts demandé pour la page en paramètre
window.requestScripts = (args) => {
    var object = JSON.parse(args);
    if (Array.isArray(object)) {
        object.forEach(async (value) => {
            $.ajax({
                type: 'GET',
                url: value,
                dataType: "script",
                success: function () {
                    console.log("Script has been loaded: " + value)
                },
                cache: true
            });
        });
    } else {
        $.ajax({
            url: object,
            dataType: "script",
            success: function () {
                console.log("Script has been loaded: " + object)
            },
            cache: true
        });
    }
};
// appel aux nouveaux styles
window.requestStyles = (args) => {
    var object = JSON.parse(args);
    if (Array.isArray(object)) {
        object.forEach(async (value) => {
            $.ajax({
                type: 'GET',
                url: value,
                dataType: "text",
                success: function (data) {
                    console.log("Style has been loaded: " + value);
                    $("head").append("<style>" + data + "</style>");
                },
                cache: true
            });
        });
    } else {
        $.ajax({
            url: object,
            dataType: "text",
            success: function (data) {
                console.log("Style has been loaded: " + value);
                $("head").append("<style>" + data + "</style>");
            },
            cache: true
        });
    }
};

// initialise la table dans la page
window.initTable = (arg) => {
    $(arg).DataTable();
    console.log("Datatable has been initialize: " + arg);
};

// initialise la référence dom pour un richtext editor 
window.InitTrumbowyg = (ref) => {
    // This the minimal code to transform a simple div into the amazing WYSIWYG editor which is Trumbowyg.
    // Allow to sanitize the code by removing all tags you want. The tagsToRemove option is an array.
    $(ref).trumbowyg({
        tagsToRemove: ['script', 'embed', 'iframe'],
        lang: 'fr', // localisation en francais
    });
};
// dispose la référence pour richtext editor pour assurer qu'il ne reste pas dans le dom
window.DisposeTrumbowyg = (ref) => {
    // This the minimal code to transform a simple div into the amazing WYSIWYG editor which is Trumbowyg.
    // Allow to sanitize the code by removing all tags you want. The tagsToRemove option is an array.
    $(ref).trumbowyg('destroy');
};
// action sur le richtext editor déjà initialisé
window.PropsTrumbowyg = (ref, attr) => {
    if (attr == 'html') {
        return $(ref).trumbowyg(attr); // Get HTML content
    }
    $(ref).trumbowyg(attr);
};



// animate on in 
window.initForm = () => {
    $('.firstLayer').show();
    $('.hiddenForm').hide();

    anime({
        targets: '.hiddenForm',
        translateX: '-300vh'
    });

    anime({
        targets: '.firstLayer',
        translateX: '0'
    });

}

// animate on in 
window.showForm = () => {
    anime({
        targets: '.hiddenForm',
        translateX: 0,
        easing: 'easeInOutQuad',
        complete: function () {
            $('.firstLayer').hide();
        }
    });

    anime({
        targets: '.firstLayer',
        translateX: '300vh',
        easing: 'easeInOutQuad',
        begin: function () {
            $('.hiddenForm').show();
        }
    });
}

// animate out
window.hideForm = () => {
    anime({
        targets: '.hiddenForm',
        translateX: '-300vh',
        easing: 'easeInOutQuad',
        begin: function () {
            $('.firstLayer').show();
        }
    });

    anime({
        targets: '.firstLayer',
        translateX: '0',
        easing: 'easeInOutQuad',
        complete: function () {
            $('.hiddenForm').hide();
        }
    });
}

window.alertDatabaseError = () => {
    alert("Erreur avec la database, durant la communication.");
}

// toggle the given element
window.toggle = (element) => {
    $(element).toggle();
}

// Toggle the side navigation
$("#sidebarToggle, #sidebarToggleTop").on('click', function (e) {
    $("body").toggleClass("sidebar-toggled");
    $(".sidebar").toggleClass("toggled");
    if ($(".sidebar").hasClass("toggled")) {
        $('.sidebar .collapse').collapse('hide');
    };
});


window.modelInitializing = () => {
    $("#loaderDepart").show();
};
window.modelLoaded = (symbol, price) => {
    $("#loaderDepart").hide();
};

// mets en valeur que le formulaire doit avoir un wasvalidated pour loader le css de validation
function validationFor(arg) {
    var form = $(arg);
    if (!form.hasClass("was-validated")) {
        form.addClass("was-validated");
    }
};


window.LoadCollapse = () => {
    $("button[data-expend-button]").on('mouseup', function (enventData) {
        var id = "#"+$(this).attr("data-expend-button");
        var container = $("#container-" + $(this).attr("data-expend-button"));        
        // a-t-il la classe?
        if (container.hasClass("col-12-important")) {            
            // si il à la classe show l'enlever et fermer et enlever la class
            if ($(id).hasClass("show")) {
                $(id).collapse("toggle"); // enlève le toggle
                // wait pour un peu d'animation
                setTimeout(function () {
                    container.removeClass("col-12-important") // enlêve la class qui la ouvre
                }, 350);
            }
            // sinon fermer l'expend et ne rien faire d'autre
            else {
                container.removeClass("col-12-important") // enlêve la class qui la ouvre
            }
            $(this).text("Afficher");
        }
        // n'a pas la classe
        else
        {
            container.addClass("col-12-important");
            $(this).text("Masquer");
            // ajouter la classe si toggle n'est pas là le toggle
            if (!$(id).hasClass("show")) {
                // wait pour un peu d'animation
                setTimeout(function () {
                    $(id).collapse("toggle"); // toggle le collapse afin qu'il souvre!                
                }, 350);
            }
        }  
    });
};