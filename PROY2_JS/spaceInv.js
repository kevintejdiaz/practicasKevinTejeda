let tileSize = 32;
let rows = 16;
let columns = 16;

let board;
let boardWidth = tileSize * columns;
let boardHeight = tileSize * rows;
let context;

let shipWidth = tileSize;
let shipHeight = tileSize * 2;
let shipX = tileSize * columns / 2 - tileSize;
let shipY = tileSize * rows - tileSize * 2;
let shipImg;
let shipVelocityX = tileSize;

let alienArray = [];
let alienWidth = tileSize * 2;
let alienHeight = tileSize;
let alienX = tileSize;
let alienY = tileSize;
let alienImg;
let alienVelocityX = 1;             
let alienSpeedIncrement = 0.2;      
let alienInitialVelocityX = 1;     

let alienRows = 2;
let alienColumns = 3;
let alienCount = 0;

let bulletArray = [];
let bulletVelocityY = -10;

let ship = {
    x: shipX,
    y: shipY,
    width: shipWidth,
    height: shipHeight
};

let score = 0;

let gameOverImg = new Image();
gameOverImg.src = "resources/GameOver.png";

let youWinImg = new Image();
youWinImg.src = "resources/winner.png";

let gameActive = true;
let animationId;

window.onload = () => {
    board = document.getElementById('board');
    board.width = boardWidth;
    board.height = boardHeight;

    context = board.getContext('2d');

    shipImg = new Image();
    shipImg.src = "resources/nave.png";
    shipImg.onload = () => {
        context.drawImage(shipImg, ship.x, ship.y, ship.width, ship.height);
    };

    alienImg = new Image();
    alienImg.src = "resources/enemigo.png";
    createAliens();

    document.addEventListener("keydown", moveShip);
    document.addEventListener("keyup", shoot);

    document.getElementById('botonJugar').addEventListener('click', () => {
        document.getElementById('overlay').style.display = 'none';
        document.getElementById('restartButton').style.display = 'inline';
        startGame();
    });

    document.getElementById('restartButton').addEventListener('click', resetGame);
};

function update() {
    if (!gameActive) return;

    animationId = requestAnimationFrame(update);

    context.clearRect(0, 0, boardWidth, boardHeight);

    context.drawImage(shipImg, ship.x, ship.y, ship.width, ship.height);

    alienArray.forEach(alien => {
        if (alien.alive) {
            context.drawImage(alienImg, alien.x, alien.y, alien.width, alien.height);
            alien.x += alienVelocityX;

            if (alien.x + alien.width >= boardWidth || alien.x <= 0) {
                alienVelocityX *= -1;  
                alienVelocityX += (alienVelocityX > 0 ? alienSpeedIncrement : -alienSpeedIncrement);  

                alienArray.forEach(a => {
                    a.y += alienHeight;
                });
            }

            if (detectCollision(alien, ship)) {
                gameActive = false;
                drawCenteredImage(gameOverImg, 300, 150);
                cancelAnimationFrame(animationId);
                disableControls();
            }
        }
    });

    bulletArray.forEach((bullet, index) => {
        bullet.y += bulletVelocityY;
        context.fillStyle = "yellow";
        context.fillRect(bullet.x, bullet.y, bullet.width, bullet.height);

        alienArray.forEach((alien, alienIndex) => {
            if (detectCollision(bullet, alien) && !bullet.used && alien.alive) {
                bullet.used = true;
                alien.alive = false;
                alienCount--;
                score += 100;
                document.getElementById('score').innerText = score;
            }
        });

        if (bullet.used || bullet.y < 0) {
            bulletArray.splice(index, 1);
        }
    });

    if (alienCount === 0 && gameActive) {
        gameActive = false;
        drawCenteredImage(youWinImg, 300, 150);
        cancelAnimationFrame(animationId);
        disableControls();
    }
}

function moveShip(e) {
    if (e.code === "ArrowLeft") {
        ship.x = Math.max(0, ship.x - shipVelocityX);
    } else if (e.code === "ArrowRight") {
        ship.x = Math.min(board.width - ship.width, ship.x + shipVelocityX);
    }
}

function createAliens() {
    alienArray = [];
    for (let c = 0; c < alienColumns; c++) {
        for (let r = 0; r < alienRows; r++) {
            let alien = {
                img: alienImg,
                x: alienX + c * alienWidth,
                y: alienY + r * alienHeight,
                width: alienWidth,
                height: alienHeight,
                alive: true
            };
            alienArray.push(alien);
        }
    }
    alienCount = alienArray.length;
}

function shoot(e) {
    if (e.code === "Space") {
        let bullet = {
            x: ship.x + ship.width / 2 - tileSize / 16,
            y: ship.y,
            width: tileSize / 8,
            height: tileSize / 2,
            used: false
        };
        bulletArray.push(bullet);
    }
}

function detectCollision(a, b) {
    return a.x < b.x + b.width &&
           a.x + a.width > b.x &&
           a.y < b.y + b.height &&
           a.y + a.height > b.y;
}

function startGame() {
    gameActive = true;
    score = 0;
    document.getElementById('score').innerText = score;
    alienVelocityX = alienInitialVelocityX;  
    createAliens();
    bulletArray = [];
    attachControls();
    update();
}

function disableControls() {
    document.removeEventListener("keydown", moveShip);
    document.removeEventListener("keyup", shoot);
}

function attachControls() {
    document.addEventListener("keydown", moveShip);
    document.addEventListener("keyup", shoot);
}

function resetGame() {
    cancelAnimationFrame(animationId);
    gameActive = true;
    score = 0;
    document.getElementById('score').innerText = score;
    ship.x = shipX;
    ship.y = shipY;
    alienVelocityX = alienInitialVelocityX;  
    bulletArray = [];
    createAliens();
    attachControls();
    context.clearRect(0, 0, boardWidth, boardHeight);
    update();
}

function drawCenteredImage(image, width, height) {
    let x = (boardWidth - width) / 2;
    let y = (boardHeight - height) / 2;
    context.drawImage(image, x, y, width, height);
}