
$(document).ready(function () {
    // init Isotope
    var $grid = $('.grid').isotope({
        itemSelector: '.grid-item',
        // layout mode options
        masonry: {
            columnWidth: 200
        }
    });
    // filter items on button click
    $('.filter-button-group').on('click', 'button', function () {
        var filterValue = $(this).attr('data-filter');
        $grid.isotope({ filter: filterValue });
    });
});