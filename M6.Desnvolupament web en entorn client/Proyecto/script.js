window.onload = () => {
    function crearTarjetas(filosofos) {
        filosofos.forEach((filosofo) => {
            // Creamos tarjeta vacía
            let tarjeta = document.createElement('div');
            tarjeta.classList.add('card');
            
            // Creamos imagen
            let imagen = document.createElement('img');
            imagen.src = filosofo.imagen;
            imagen.alt = `Foto de ${filosofo.nombre}`;
            imagen.classList.add('photo');
            tarjeta.append(imagen);
        
            // Creamos caja de información
            let info = document.createElement('div');
            info.classList.add('card-info');
            tarjeta.append(info);
        
            // Creamos título
            let titulo = document.createElement('h3');
            titulo.classList.add('nombre');
            titulo.innerHTML = filosofo.nombre;
            info.append(titulo);
        
            // Creamos fila de información (info-row)
            let filaInfo = document.createElement('div');
            filaInfo.classList.add('info-row');
            info.append(filaInfo);
        
            // Añadimos info del país a filaInfo
            let paisInfo = document.createElement('div');
            paisInfo.classList.add('info-pais');
            
            let paisImagen = document.createElement('img');
            paisImagen.src = filosofo.pais.bandera;
            paisImagen.alt = `Bandera de ${filosofo.pais.nombre}`;
            paisInfo.append(paisImagen);
        
            let paisNombre = document.createElement('span');
            paisNombre.classList.add('pais');
            paisNombre.textContent = filosofo.pais.nombre;
            paisInfo.append(paisNombre);
            
            filaInfo.append(paisInfo);
        
            // Añadimos info de la corriente a filaInfo
            let corrienteInfo = document.createElement('div');
            corrienteInfo.classList.add('info-corriente');
        
            let corrienteLabel = document.createElement('span');
            corrienteLabel.textContent = 'Corriente: ';
            corrienteInfo.append(corrienteLabel);
        
            let corriente = document.createElement('span');
            corriente.classList.add('corriente');
            corriente.textContent = filosofo.corriente;
            corrienteInfo.append(corriente);
        
            filaInfo.append(corrienteInfo);
        
            // Añadimos info del arma a filaInfo
            let armaInfo = document.createElement('div');
            armaInfo.classList.add('info-arma');
        
            let armaLabel = document.createElement('span');
            armaLabel.textContent = 'Arma: ';
            armaInfo.append(armaLabel);
        
            let arma = document.createElement('span');
            arma.classList.add('arma');
            arma.textContent = filosofo.arma;
            armaInfo.append(arma);
        
            filaInfo.append(armaInfo);
        
            // Añadimos caja de habilidades
            let habilidades = document.createElement('div');
            habilidades.classList.add('skills');
            info.append(habilidades);
        
            // Añadimos una a una las habilidades
            for (let infoHabilidad of filosofo.habilidades) {
                let habilidad = document.createElement('div');
                habilidad.classList.add('skill');
                habilidades.append(habilidad);
        
                // let icono = document.createElement('img');
                // // icono.src = infoHabilidad.icono; // Asegúrate de que `icono` esté definido en `infoHabilidad`.
                // icono.alt = `Icono de ${infoHabilidad.habilidad}`;
                // habilidad.append(icono);
        
                let etiqueta = document.createElement('span');
                etiqueta.classList.add('skill-name');
                etiqueta.textContent = infoHabilidad.habilidad;
                habilidad.append(etiqueta);
        
                let barraNivel = document.createElement('div');
                barraNivel.classList.add('skill-bar');
                habilidad.append(barraNivel);
        

                let nivel = document.createElement('div');
                nivel.classList.add('level');
                nivel.style.width = `${infoHabilidad.nivel * 25}%`; // Suponiendo que nivel es de 1 a 4, ajustamos el ancho proporcionalmente.
                barraNivel.append(nivel);


                habilidad.append(barraNivel);
                habilidades.append(habilidad);
            }
        
            // Añadimos tarjeta creada al contenedor de tarjetas
            let contenedor = document.querySelector('.cards-container');
            contenedor.append(tarjeta);
        });
        
    }
    crearTarjetas(filosofos)

    // Crear handlers para los botones de control
    let botonCrearTarjeta = document.querySelector('.create-btn');
    botonCrearTarjeta.addEventListener('click',crearNuevaTarjeta);
}



function eliminarTarjeta() {
}

function ordenarNombreAZ() {
    let tarjetas = Array.from(document.querySelectorAll('.card'));
    let tarjetasOrdenadas = tarjetas.sort((tarjetaA, tarjetaB) => {
        let nombre1 = tarjetaA.querySelector('h3').innerHTML;
        let nombre2 = tarjetaB.querySelector('h3').innerHTML;
        return nombre1.localeCompare(nombre2);
    });

    // Eliminar totes les targetes de l'array 'tarjeta'
    // Completar codi

    // Afegir 'tarjetasOrdenadas' al contenidor de cards
    let contenedor = document.querySelector('.cards-container');
    // Completar codi
}

function ordenarNombreZA() {
}

function crearNuevaTarjeta(event) {
    event.preventDefault();
    let nuevoFilosofo = {};
    nuevoFilosofo.nombre = document.querySelector('.create-card-form .nombre').value;
    nuevoFilosofo.imagen = document.querySelector('.create-card-form .foto').value;
    nuevoFilosofo.pais = {};
    nuevoFilosofo.pais.nombre = document.querySelector('.create-card-form .pais').value;
    // Completar la función

    // crearTarjetas(nuevoFilosofo);
}

function parsearTarjetas(tarjetas){
    let filosofosParseados = [];
    for (let tarjeta of tarjetas){
        let filosofo = {};
        filosofo.nombre = tarjeta.querySelector('.nombre').innerHTML;
        filosofo.imagen = tarjeta.querySelector('.photo').src;
        filosofo.pais = {};
        // Completar funció
        
        let habilidades = tarjeta.querySelectorAll('.skill');
        for (let habilidad of habilidades){
            let habilidadParaGuardar = {};
            // Completar funció
        }
        filosofosParseados.push(filosofo);
    }
    return filosofosParseados;
}

function guardarTarjetas(){
    let tarjetas = Array.from(document.querySelectorAll('.card'));
    localStorage.setItem('tarjetas',JSON.stringify(parsearTarjetas(tarjetas)));
}


function cargarTarjetas() {
}

const filosofos = [
    {
        nombre: "Platón",
        imagen: "https://upload.wikimedia.org/wikipedia/commons/thumb/d/da/Plato_Pio-Clemetino_Inv305.jpg/1200px-Plato_Pio-Clemetino_Inv305.jpg",
        pais: {
            nombre: "Grecia",
            bandera: "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Flag_of_Greece.svg/640px-Flag_of_Greece.svg.png"
        },
        corriente: "Idealismo",
        arma: "Dialéctica",
        habilidades: [{
            habilidad: "Sabiduría",
            nivel: 4
        },
        {
            habilidad: "Oratoria",
            nivel: 4
        },
        {
            habilidad: "Lógica",
            nivel: 3
        },
        {
            habilidad: "Innovación",
            nivel: 4
        }
        ]
    },
    {
        nombre: "Aristóteles",
        imagen: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQdXUwy_fFGOJ2vwOMpwtJPyXc9HVb06HSRsbembn7IPKq6D1YitIra2WFM4Gu2rm6yHRs&usqp=CAU",
        pais: {
            nombre: "Grecia",
            bandera: "https://upload.wikimedia.org/wikipedia/commons/thumb/5/5c/Flag_of_Greece.svg/640px-Flag_of_Greece.svg.png"
        },
        corriente: "Naturalismo",
        arma: "Lógica",
        habilidades: [{
            habilidad: "Sabiduría",
            nivel: 4
        },
        {
            habilidad: "Oratoria",
            nivel: 3
        },
        {
            habilidad: "Lógica",
            nivel: 4
        },
        {
            habilidad: "Innovación",
            nivel: 3
        }
        ]
    },
    {
        nombre: "Descartes",
        imagen: "https://upload.wikimedia.org/wikipedia/commons/thumb/7/73/Frans_Hals_-_Portret_van_Ren%C3%A9_Descartes.jpg/800px-Frans_Hals_-_Portret_van_Ren%C3%A9_Descartes.jpg",
        pais: {
            nombre: "Francia",
            bandera: "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c3/Flag_of_France.svg/1280px-Flag_of_France.svg.png"
        },
        corriente: "Racionalismo",
        arma: "Meditación",
        habilidades: [{
            habilidad: "Sabiduría",
            nivel: 3
        },
        {
            habilidad: "Oratoria",
            nivel: 3
        },
        {
            habilidad: "Lógica",
            nivel: 2
        },
        {
            habilidad: "Innovación",
            nivel: 3
        }
        ]
    },
    {
        nombre: "Kant",
        imagen: "https://i.pinimg.com/736x/20/89/7f/20897f915acb5124893a278c395382ed.jpg",
        pais: {
            nombre: "Alemania",
            bandera: "https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Flag_of_Germany.svg/255px-Flag_of_Germany.svg.png"
        },
        corriente: "Trascendentalismo",
        arma: "Crítica",
        habilidades: [{
            habilidad: "Sabiduría",
            nivel: 3
        },
        {
            habilidad: "Oratoria",
            nivel: 2
        },
        {
            habilidad: "Lógica",
            nivel: 3
        },
        {
            habilidad: "Innovación",
            nivel: 3
        }
        ]
    },
    {
        nombre: "Hume",
        imagen: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSiFZYg2MiOQSXbkBvFP-T3vW9pnhLW5qDioA&s",
        pais: {
            nombre: "Escocia",
            bandera: "https://upload.wikimedia.org/wikipedia/commons/thumb/1/10/Flag_of_Scotland.svg/640px-Flag_of_Scotland.svg.png"
        },
        corriente: "Empirismo",
        arma: "Escepticismo",
        habilidades: [{
            habilidad: "Sabiduría",
            nivel: 3
        },
        {
            habilidad: "Oratoria",
            nivel: 3
        },
        {
            habilidad: "Lógica",
            nivel: 3
        },
        {
            habilidad: "Innovación",
            nivel: 3
        }
        ]
    },
    {
        nombre: "Arendt",
        imagen: "https://efeminista.com/wp-content/uploads/2021/09/Arendt-Hannah-1-e1576158475623.jpg",
        pais: {
            nombre: "Alemania",
            bandera: "https://upload.wikimedia.org/wikipedia/commons/thumb/b/ba/Flag_of_Germany.svg/255px-Flag_of_Germany.svg.png"
        },
        corriente: "Fenomenología",
        arma: "Parresía",
        habilidades: [{
            habilidad: "Sabiduría",
            nivel: 3
        },
        {
            habilidad: "Oratoria",
            nivel: 2
        },
        {
            habilidad: "Lógica",
            nivel: 2
        },
        {
            habilidad: "Innovación",
            nivel: 3
        }
        ]
    }
]