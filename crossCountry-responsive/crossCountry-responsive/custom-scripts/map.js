

var MYMAP = {
    bounds: null,
    map: null,
    myLatLng: null,
    directionsDisplay: null,
    directionService: null,
    marker: null,
    markersArray: [],
    placemarks: [],
    startlat: null,
    startlng: null,
    endlat: null,
    endlng: null,
    northeast: null,
    southwest: null,
    selectedMarkerArray: [] //markers are added and removed from this array on each marker toggle

}


MYMAP.placemarkAjax = function (xml) {

    MYMAP.clearOverlays(); //clearing previous placemarks
    var childs = $(xml).find("markers").children();
    var length = childs.length;
    var i = 0;
  //  var icon = 'images/unchecked.png';
    var lattemp
    var lngtemp
    MYMAP.bounds = new google.maps.LatLngBounds();
    $(xml).find("marker").each(function () {

        var claimNo = $(this).find('claimNo').text();
      //  var insuredName = $(this).find('insuredName').text();
     //   var Adjuster = $(this).find('Adjuster').text();
     //   var title = $(this).find('title').text();
      //  var address = $(this).find('address').text();
      //  var adjuster = $(this).find('adjuster').text();
        // create a new LatLng point for the marker
        var lat = parseFloat($(this).find('lat').text());
        var lng = parseFloat($(this).find('lng').text());
        var point = new google.maps.LatLng(lat, lng);


        // extend the bounds to include the new point
        try {
            MYMAP.bounds.extend(point);
            }
        catch (e) {
            //$('#iconmenu').hide().delay(700).show('fast');
            alert(e.message);
        }
        // add the marker itself

        MYMAP.placemarks[i] = new google.maps.Marker({
            position: point,
            selected: false,
            map: MYMAP.map,
            icon: '' + icon + '',
            draggable: false,
            animation: google.maps.Animation.DROP,
            shadow: 'https://labs.google.com/ridefinder/images/mm_20_shadow.png'
        });

        // create the tooltip and its text
       // var url = 'listingdetail.aspx?phyid=' + listId
      
        var html = '<div class="listingTitle">' +
                   //'<table>' +
                  // '<tr>' +
                  // '</td><td><a href="' + url + '">' + title + '</a></td></tr>' +
                  //  '<tr>' +
                  // '</td><td>' + location + '</td></tr>' +
                  // '</table>' +
                   '</div>'



        MYMAP.addMarkerInfo(html, MYMAP.placemarks[i]);
        MYMAP.enableSelectMarker(MYMAP.placemarks[i]);

        i++;
        lattemp = lat
        lngtemp = lng
    });
    MYMAP.map.fitBounds(MYMAP.bounds)

}


MYMAP.getLatLng = function (lat, lng) {
    var LatLng = new google.maps.LatLng(lat, lng);
    return LatLng
}

MYMAP.clearOverlays = function () {
    if (MYMAP.marker) {
        MYMAP.marker.setMap(null);
    }
    if (MYMAP.placemarks) {
        for (var i in MYMAP.placemarks) {
            MYMAP.placemarks[i].setMap(null);
        }
    }
}



MYMAP.init = function (lat, lng, zoom) {
    var latLng = new google.maps.LatLng(lat, lng);
    var myOptions = {
        zoom: zoom,
        center: latLng,
        mapTypeId: google.maps.MapTypeId.TERRAIN
    }
    this.map = new google.maps.Map(document.getElementById("map_canvas"), myOptions);
    this.bounds = new google.maps.LatLngBounds();
}


MYMAP.addMarkerInfo = function (html, marker) {
    var infoWindow = new google.maps.InfoWindow();
    google.maps.event.addListener(marker, 'click', function () {

        infoWindow.setContent(html);
        infoWindow.open(MYMAP.map, marker);

    });
    //    google.maps.event.addListener(marker, 'mouseout', function () {

    //  });

}

MYMAP.fitMapBounds = function () {

    try {

        MYMAP.map.fitBounds(new google.maps.LatLngBounds(MYMAP.bounds));
    }
    catch (e) {
        alert(e.message);
    }
};

MYMAP.isObject = function (what) {
    return (typeof what == 'object');
}




