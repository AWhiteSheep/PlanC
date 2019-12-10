// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

/**
 *
 * Yan Ha Routhier-Chevrier
 * Page - blazor
 *
 * */

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


// Write your JavaScript code.
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
});


window.modelInitializing = () => {
    $("#loaderDepart").show();
};
window.modelLoaded = (symbol, price) => {
    $("#loaderDepart").hide();
};

// Close any open menu accordions when window is resized below 768px
$(window).resize(function () {
    if ($(window).width() < 768) {
        //$('.sidebar .collapse').collapse('hide');
    };
});

// Prevent the content wrapper from scrolling when the fixed side navigation hovered over
$('body.fixed-nav .sidebar').on('mousewheel DOMMouseScroll wheel', function (e) {
    if ($(window).width() > 768) {
        var e0 = e.originalEvent,
            delta = e0.wheelDelta || -e0.detail;
        this.scrollTop += (delta < 0 ? 1 : -1) * 30;
        e.preventDefault();
    }
});

// Scroll to top button appear
$(document).on('scroll', function () {
    var scrollDistance = $(this).scrollTop();
    if (scrollDistance > 100) {
        $('.scroll-to-top').fadeIn();
    } else {
        $('.scroll-to-top').fadeOut();
    }
});

// Smooth scrolling using jQuery easing
$(document).on('click', 'a.scroll-to-top', function (e) {
    var $anchor = $(this);
    $('html, body').stop().animate({
        scrollTop: ($($anchor.attr('href')).offset().top)
    }, 1000, 'easeInOutExpo');
    e.preventDefault();
});

// autocomplete 
var values = [
    { value: 'Admin', data: '/admin' },
    { value: 'Competence', data: '/personnel/competences' },
    { value: 'Nouvelle competence', data: '/personnel/competences/nouvelle' },
    { value: 'Document', data: '/personnel/documents' },
    { value: 'Plans cadre', data: '/personnel/planscadres' },
];

var autocompleter = $('#autocomplete');

$('#autocomplete').autocomplete({
    lookup: values,
    noCache: true,
    onSelect: function (suggestion) {
        location.replace(suggestion.value);
    },
    // ui est vide
    onSearchStart: function (suggestions) {
        console.log(suggestions);
        $('#autocomplete').addClass("autocomplete-open");
    },
    onHide: function (container) {
        $('#autocomplete').removeClass("autocomplete-open");
    }
});

// pour les clickables de la top bar
$(document).on('click', '.panel-heading span.clickable', function (e) {
    var $this = $(this);
    if (!$this.hasClass('panel-collapsed')) {
        $this.parents('.panel').find('.panel-body').slideUp();
        $this.addClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-down').addClass('glyphicon-chevron-up');

    } else {
        $this.parents('.panel').find('.panel-body').slideDown();
        $this.removeClass('panel-collapsed');
        $this.find('i').removeClass('glyphicon-chevron-up').addClass('glyphicon-chevron-down');

    }
})

// confirmation post de la deconnection
function deconnection() {

    var data = {
        // token caché dans la page afin de ne pas avoir le rediriger ver un pas de déconeccexion
        RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    // envoit de la demande en ajax avec le data demandé
    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Logout",
        headers: {
            'RequestVerificationToken': data['RequestVerificationToken']
        },
        data: JSON.stringify(data),
        success: function (data, textStatus) {
            if (textStatus == "success") {
                window.location = "/Compte/Logout"
            }
        },
        error: function (data, status, error) {
            alert(error);
        }
    });
}

// tiles javascript
$('.me-card').each(function (i, e) {
    // https://github.com/material-components/material-components-web/blob/master/docs/getting-started.md
    // attache à l'élément une joyeuse apparence 
    mdc.ripple.MDCRipple.attachTo(e);
});