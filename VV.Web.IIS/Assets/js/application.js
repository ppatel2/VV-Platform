//Window on Load Function
$(window).load(function() {
    initMenuToggle();
    initActiveMenu();
});

//initMenu and init the on click listener 
function initMenuToggle() {
	$('[data-tooltip-type="alwaysOn"]').tooltip('enable');
    $("#menuToggle, .sidebarBrand").click(function(e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
        $('.menuToggleIcon').toggleClass("fa-flip-horizontal");
        $('.navHidden').toggle();
    });
};

function initActiveMenu() {
    $(".sidebarTab").click(function(e) {
       $(this).siblings().removeClass('activeTab');
        $(this).addClass('activeTab');
    });
};
