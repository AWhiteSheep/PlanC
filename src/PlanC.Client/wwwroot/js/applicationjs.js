// main js for the blazor application

// god bless stackoverflow
// https://stackoverflow.com/questions/57366355/how-do-i-use-blazor-server-side-inside-a-razor-component-library-using-areas
Blazor.start({
    configureSignalR: function (builder) {
        builder.withUrl("/_blazor");
        builder.withAutomaticReconnect();
    }
});

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