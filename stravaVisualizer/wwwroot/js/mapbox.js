mapboxgl.accessToken = 'pk.eyJ1IjoiaXNhYWNmYWxvcmVzMiIsImEiOiJjazAzMTB5YnYyb293M21wZmh1NnRtdjNqIn0.iUw2jdHRohldI12Lxm-u6Q'

function addMarkerToMap(map) {
    var marker = new mapboxgl.Marker()
        .setLngLat([-122.6952182, 47.1002495])
        .addTo(map)
}

function renderMap(center) {
    var map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/mapbox/streets-v11',
        center: center,
        zoom: 13

    })
    
}

function renderMapWithMarker(center, marker) {
    centerLongLat = convertLatLongStrToLongLatFloat(center)
    markerLongLat = convertLatLongStrToLongLatFloat(marker)

    var map = new mapboxgl.Map({
        container: 'map',
        style: 'mapbox://styles/mapbox/streets-v11',
        center: [-122.97, 47.04], //centerLongLat
        zoom: 13
    })
    addMarkerToMap([-122.97, 47.04])
}

function convertLatLongStrToLongLatFloat(latlong) {
    latlongStrArray = latlong.split(",")
    longlatFloatArray = [parseFloat(latlongStrArray[1]), parseFloat(latlongStrArray[0])]
    return longlatFloatArray;
}

