

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
    var icon = '../Resources/unchecked.png';
    var lattemp
    var lngtemp
    MYMAP.bounds = new google.maps.LatLngBounds();
    $(xml).find("marker").each(function () {

        var claimNo = $(this).find('claimNo').text();
        var insuredName = $(this).find('insuredName').text();
        var Adjuster = $(this).find('Adjuster').text();
        var title = $(this).find('title').text();
        var address = $(this).find('address').text();
        var adjuster = $(this).find('adjuster').text();
        // create a new LatLng point for the marker
        var lat = parseFloat($(this).find('lat').text());
        var lng = parseFloat($(this).find('lng').text());
        var point = new google.maps.LatLng(lat, lng);



        //        if (lat+lng> lattemp+lngtemp) {
        //            MYMAP.startlat = lat
        //            MYMAP.startlng = lng
        //        }
        //        else {
        //            MYMAP.startlat = lattemp
        //            MYMAP.starlng = lngtemp
        //        }

        //        if (lat+lng < lattemp+lngtemp) {
        //            MYMAP.endlat = lat
        //            MYMAP.endlng = lng
        //        }
        //        else {
        //            MYMAP.endlat = lattemp
        //            MYMAP.endlng = lngtemp
        //        }



        // extend the bounds to include the new point
        try {
            MYMAP.bounds.extend(point);

            //MYMAP.map.setCenter(point)
            //MYMAP.map.panTo(point)
            //MYMAP.map.panToBounds(point);
        }
        catch (e) {
            //$('#iconmenu').hide().delay(700).show('fast');
            alert(e.message);
        }
        // add the marker itself

        MYMAP.placemarks[i] = new google.maps.Marker({
            position: point,
            claimno: claimNo,
            selected: false,
            map: MYMAP.map,
            icon: '' + icon + '',
            draggable: false,
            animation: google.maps.Animation.DROP,
            // shadow: 'https://labs.google.com/ridefinder/images/mm_20_shadow.png'
        });

        // create the tooltip and its text

        var html = '<b>' + 'Claim # : ' + claimNo + '</b><br />' + '<b>' + 'Insured Name: ' + insuredName + '</b><br />' + '<b>' + 'Adjuster :' + '</b>' + adjuster + '<b>' + '<br />' + 'Location: ' + '</b>' + address;

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
    google.maps.event.addListener(marker, 'mouseover', function () {

        infoWindow.setContent(html);
        infoWindow.open(MYMAP.map, marker);
        //MYMAP.map.extend(null);
    });
    google.maps.event.addListener(marker, 'mouseout', function () {
        infoWindow.setContent(null);
        infoWindow.close();
    });
    //MYMAP.fitMapBounds();



}

MYMAP.fitMapBounds = function () {
    //MYMAP.northeast = new google.maps.LatLng(31.00704,-87.378593)
    //MYMAP.southwest = new google.maps.LatLng(30.475899, -88.712059)
    //MYMAP.bounds = new google.maps.LatLngBounds(MYMAP.southwest, MYMAP.northeast);
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



MYMAP.unselectMarkers = function (length) {
    for (var i = 0; i < length; i++) {
        map.unselect();
    }
}

MYMAP.enableSelectMarker = function (marker) {
    google.maps.event.addListener(marker, 'click', function (e) {
        //select/deselect markers
        if (marker.selected) {
            marker.selected = false
            marker.setIcon('../Resources/unchecked.png')
            //alert(marker.claimno + ' deselected')
            MYMAP.selectedMarkerArray.push(marker.claimno)

            //alert(marker.position.Latitude)
            //return marker.claimno
        }
        else {
            marker.selected = true
            marker.setIcon('../Resources/checked.png')
            //alert(marker.claimno + ' selected')
            var index = MYMAP.selectedMarkerArray.indexOf(marker.claimno)
            MYMAP.selectedMarkerArray.splice(index, 1)
        }


        $("[id*=gdClaimCount] tr").each(function () {
            var gdclaimno = ""

            if ($(this).find("td:nth-child(2)").html() != null) {
                var gdclaimno = $(this).find("td:nth-child(2)").html();
            }


            if (gdclaimno.toString() == marker.claimno.toString() && gdclaimno != null && marker.selected == true) {
                $(this).find("input[id*='assignCheckbox']:checkbox").attr('checked', true);

            }
            if (gdclaimno.toString() == marker.claimno.toString() && gdclaimno != null && marker.selected == false) {
                $(this).find("input[id*='assignCheckbox']:checkbox").attr('checked', false);

            }



        });


        return false;

    });

}




MYMAP.getSelectedMarkerValues = function () {
    return MYMAP.selectedMarkerArray;
}

//		MYMAP.doSearch=function() {
//			var query = $('#searchInput').val();
//			gLocalSearch.setCenterPoint(gMap.getCenter());
//			gLocalSearch.execute(query);
//		}

//		MYMAP.toggleBounce=function(marker) {
//			if (marker.getAnimation() != null) {
//			marker.setAnimation(null);
//			} else {
//			marker.setAnimation(google.maps.Animation.BOUNCE);
//			}
//		}

