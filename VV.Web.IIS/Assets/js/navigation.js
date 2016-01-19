//Window on Load Function

//initMenu and init the on click listener 
function initMenuAjax() {
	$("#sidebarWrapper").click(function(e) {
        e.preventDefault();
        var targetId = e.target.id;
        var targetLink = $('#' + targetId).attr("href");
        console.log(targetLink);
        if (targetLink != undefined) {
             $.get(targetLink, function (data) {
                 $("#page-wrapper").html(data);
                  console.log(data);
             });
        } else {
             return;
        };       

    });
};



