$.fn.bootstrapImageViewer=function(options){
	$(this).on('click',function(){
		var opts=$.extend({},$.fn.bootstrapImageViewer.defaults,options);
    var viewer=$('<div class="modal fade bs-example-modal-lg text-center" id="bootstrapImageViewer" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" >\n' +
        '          <div class="modal-dialog modal-lg" style="display: inline-block; width: auto;">\n' +
        '            <div class="modal-content">\n' +
        '             <img' +
        '\t\t\t class="carousel-inner img-responsive img-rounded img-viewer" \n' +
        '\t\t\t onclick="$(\'#bootstrapImageViewer\').modal(\'hide\');setTimeout(function(){$(\'#bootstrapImageViewer\').remove();},200);"\n' +
        '\t\t\t onmouseover="this.style.cursor=\'zoom-out\';" \n' +
        '\t\t\t onmouseout="this.style.cursor=\'default\'"  \n' +
        '\t\t\t />\n' +
        '            </div>\n' +
        '          </div>\n' +
        '        </div>');
    $('body').append(viewer);
    if ($(this).attr(opts.src)) {
    	 $("#bootstrapImageViewer").find(".img-viewer").attr("src",$(this).attr(opts.src));
    	 $("#bootstrapImageViewer").modal();
	}else{
		throw "图片不存在"
	}
   
	})

	$(this).on('mouseover',function(){
		$(this).css('cursor','zoom-in');
	})
   
}
$.fn.bootstrapImageViewer.defaults={
    src:'src'
}