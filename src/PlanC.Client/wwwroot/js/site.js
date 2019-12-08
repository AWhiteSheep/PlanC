﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


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

var values = [
    { value: 'Admin', data: '/admin' },
    { value: 'Competence', data: '/personnel/competences' },
    { value: 'Nouvelle competence', data: '/personnel/competences/nouvelle' },
    { value: 'Document', data: '/personnel/documents' },
    { value: 'Plans cadre', data: '/personnel/planscadres' },
];

$('#autocomplete').autocomplete({
    lookup: values,
    onSelect: function (suggestion) {
        location.replace(suggestion.value);
    }
});

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


function deconnection() {

    var data = {
        RequestVerificationToken: $("[name='__RequestVerificationToken']").val()
    };

    $.ajax({
        type: "POST",
        contentType: "application/json",
        url: "/Compte/Logout",
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