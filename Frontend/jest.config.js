module.exports = {
  // Activa la recolección de cobertura
  collectCoverage: true,
  // Define dónde se guardará el reporte
  coverageDirectory: "coverage",
  // Formato del reporte (HTML para que puedas imprimirlo a PDF)
  coverageReporters: ["html"],
  // IMPORTANTE: Le indicamos que SOLO mida la carpeta donde pondrás tu lógica pura
  collectCoverageFrom: [
    "assets/js/logica/**/*.js" 
  ]
};