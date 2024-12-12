let tileSize = 32;
let rows = 16;
let columns= 16;


let board;
let boardWidth = tileSize * columns;
let boardHeight = tileSize *rows;
let context;


let shipWidth = tileSize;
let shipHeight = tileSize*2;
let shipX = tileSize * columns/2 -tileSize
let shipY = tileSize * rows - tileSize*2
let shipImg;
let ship = {
    x: shipX,
    y: shipY,
    width: shipWidth,
    height: shipHeight
}

window.onload = () => {
    board = document.getElementById('board');
    board.width = window.innerWidth;
    board.height = window.innerHeight;

    context = board.getContext('2d');

    shipImg = new Image();
    shipImg.src= "resources/nave.png";
    shipImg.onload =  () =>
        {
        context.drawImage(shipImg, ship.x, ship.y, ship.width, ship.height);
        }

    document.getElementById('botonJugar').addEventListener('click', () => {
        document.getElementById('overlay').style.display = 'none'; // Oculta la capa
        startGame();
    });

}



function startGame() {
    console.log("¡El juego ha comenzado!");
    context.drawImage(shipImg, ship.x, ship.y, ship.width, ship.height);
}