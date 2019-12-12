$("#table_wrapper").bind("DOMSubtreeModified", function () {
    $("a[data-dt-idx]").each(function () {
        $(this).removeAttr("href");
    });
});