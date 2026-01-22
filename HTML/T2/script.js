// ===== CONFIGURACIÓN GLOBAL =====
const CONFIG = {
    animations: {
        scrollOffset: 100,
        scrollThreshold: 0.1
    }
};

// ===== NAVEGACIÓN MÓVIL =====
class MobileNavigation {
    constructor() {
        this.menuBtn = document.querySelector('.menu-btn');
        this.mainNav = document.querySelector('.main-nav');
        this.navLinks = document.querySelectorAll('.main-nav a');
        this.isOpen = false;
        
        this.init();
    }
    
    init() {
        this.setupEventListeners();
        this.setupAccessibility();
    }
    
    setupEventListeners() {
        // Botón del menú
        this.menuBtn?.addEventListener('click', (e) => {
            e.stopPropagation();
            this.toggleMenu();
        });
        
        // Cerrar menú al hacer clic en enlace
        this.navLinks.forEach(link => {
            link.addEventListener('click', () => this.closeMenu());
        });
        
        // Cerrar menú al hacer clic fuera
        document.addEventListener('click', (e) => {
            if (this.isOpen && !this.mainNav?.contains(e.target) && e.target !== this.menuBtn) {
                this.closeMenu();
            }
        });
        
        // Cerrar con Escape
        document.addEventListener('keydown', (e) => {
            if (e.key === 'Escape' && this.isOpen) {
                this.closeMenu();
            }
        });
    }
    
    setupAccessibility() {
        this.menuBtn?.setAttribute('aria-expanded', 'false');
        this.menuBtn?.setAttribute('aria-controls', 'main-navigation');
    }
    
    toggleMenu() {
        this.isOpen = !this.isOpen;
        
        if (this.isOpen) {
            this.openMenu();
        } else {
            this.closeMenu();
        }
    }
    
    openMenu() {
        this.mainNav?.classList.add('open');
        this.menuBtn?.setAttribute('aria-expanded', 'true');
        this.isOpen = true;
        
        // Enfocar primer enlace del menú
        setTimeout(() => {
            this.navLinks[0]?.focus();
        }, 100);
    }
    
    closeMenu() {
        this.mainNav?.classList.remove('open');
        this.menuBtn?.setAttribute('aria-expanded', 'false');
        this.isOpen = false;
        
        // Devolver foco al botón del menú
        this.menuBtn?.focus();
    }
}

// ===== OBSERVADOR DE NAVEGACIÓN MEJORADO =====
class NavigationObserver {
    constructor() {
        this.sections = document.querySelectorAll('section[id]');
        this.navLinks = document.querySelectorAll('.main-nav a');
        this.currentActive = null;
        this.lastScrollTop = 0;
        this.scrollTimeout = null;
        
        this.init();
    }
    
    init() {
        if (this.sections.length === 0 || this.navLinks.length === 0) return;
        
        this.createObserver();
        this.setupNavLinks();
        this.setupScrollHandler();
        
        // Establecer sección activa inicial
        setTimeout(() => this.updateActiveSection(), 100);
    }
    
    createObserver() {
        // Configuración mejorada para detectar secciones
        const options = {
            root: null,
            rootMargin: '-100px 0px -200px 0px', // Margen más conservador
            threshold: [0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9, 1.0]
        };
        
        const observer = new IntersectionObserver((entries) => {
            let mostVisibleSection = null;
            let highestVisibility = 0;
            
            entries.forEach(entry => {
                if (entry.isIntersecting) {
                    // Calcular qué porcentaje de la sección es visible
                    const visiblePercentage = entry.intersectionRatio;
                    
                    if (visiblePercentage > highestVisibility) {
                        highestVisibility = visiblePercentage;
                        mostVisibleSection = entry.target.id;
                    }
                }
            });
            
            if (mostVisibleSection && highestVisibility > 0.2) {
                this.setActiveSection(mostVisibleSection);
            }
        }, options);
        
        this.sections.forEach(section => {
            observer.observe(section);
        });
    }
    
    setupScrollHandler() {
        // Usar throttle para mejor rendimiento
        window.addEventListener('scroll', () => {
            if (this.scrollTimeout) {
                clearTimeout(this.scrollTimeout);
            }
            
            this.scrollTimeout = setTimeout(() => {
                this.updateActiveSection();
            }, 50);
        }, { passive: true });
    }
    
    updateActiveSection() {
        const scrollPosition = window.scrollY + 150; // Offset para activar antes
        let currentSection = null;
        let closestDistance = Infinity;
        
        // Encontrar la sección más cercana a la posición de scroll
        this.sections.forEach(section => {
            const sectionTop = section.offsetTop;
            const sectionHeight = section.offsetHeight;
            const sectionBottom = sectionTop + sectionHeight;
            
            // Calcular distancia al centro de la pantalla
            const viewportCenter = scrollPosition + (window.innerHeight / 3);
            const sectionCenter = sectionTop + (sectionHeight / 2);
            const distance = Math.abs(viewportCenter - sectionCenter);
            
            // Si el scroll está dentro de los límites de la sección
            if (scrollPosition >= sectionTop - 100 && 
                scrollPosition <= sectionBottom - 100) {
                
                if (distance < closestDistance) {
                    closestDistance = distance;
                    currentSection = section.id;
                }
            }
        });
        
        // Si no encontramos sección, verificar si estamos en el top
        if (!currentSection && scrollPosition < 100) {
            currentSection = 'about';
        }
        
        // Si encontramos una sección, activarla
        if (currentSection) {
            this.setActiveSection(currentSection);
        }
    }
    
    setActiveSection(sectionId) {
        // Evitar actualizaciones innecesarias
        const currentActiveId = this.currentActive?.getAttribute('href')?.substring(1);
        if (currentActiveId === sectionId) return;
        
        // Remover clase activa de todos los enlaces
        this.navLinks.forEach(link => {
            link.classList.remove('active');
            link.setAttribute('aria-current', 'false');
        });
        
        // Encontrar y activar el enlace correspondiente
        const activeLink = document.querySelector(`.main-nav a[href="#${sectionId}"]`);
        if (activeLink) {
            activeLink.classList.add('active');
            activeLink.setAttribute('aria-current', 'true');
            this.currentActive = activeLink;
            
            // Debug en consola (puedes comentarlo después)
            console.log(`Sección activada: ${sectionId}`);
        }
    }
    
    setupNavLinks() {
        this.navLinks.forEach(link => {
            link.addEventListener('click', (e) => {
                const href = link.getAttribute('href');
                
                if (href.startsWith('#')) {
                    // Remover clase activa de todos los enlaces
                    this.navLinks.forEach(l => {
                        l.classList.remove('active');
                        l.setAttribute('aria-current', 'false');
                    });
                    
                    // Agregar clase activa al enlace clickeado
                    link.classList.add('active');
                    link.setAttribute('aria-current', 'true');
                    this.currentActive = link;
                }
            });
        });
    }
}

// ===== ANIMACIÓN DE SCROLL INFINITO PARA HABILIDADES =====
class InfiniteScrollSkills {
    constructor() {
        this.skillsTrack = document.querySelector('.skills-track');
        this.skillsContainer = document.querySelector('.skills-carousel');
        this.skillCards = document.querySelectorAll('.skill-card');
        
        this.init();
    }
    
    init() {
        if (!this.skillsTrack || this.skillCards.length === 0) return;
        
        // Ocultar controles del carrusel
        this.hideCarouselControls();
        
        // Duplicar las tarjetas para efecto infinito
        this.duplicateCards();
        
        // Configurar animación CSS
        this.setupAnimation();
        
        // Configurar interacciones por clic
        this.setupCardInteractions();
        
        // Manejar responsive
        window.addEventListener('resize', () => {
            this.updateAnimationSpeed();
        });
    }
    
    hideCarouselControls() {
        const prevBtn = document.querySelector('.skill-prev');
        const nextBtn = document.querySelector('.skill-next');
        const dotsContainer = document.querySelector('.skills-dots');
        
        if (prevBtn) prevBtn.style.display = 'none';
        if (nextBtn) nextBtn.style.display = 'none';
        if (dotsContainer) dotsContainer.style.display = 'none';
    }
    
    duplicateCards() {
        // Si ya están duplicadas, no hacer nada
        if (this.skillsTrack.children.length > this.skillCards.length * 2) return;
        
        // Clonar todas las tarjetas y agregarlas al final
        const cards = Array.from(this.skillCards);
        cards.forEach(card => {
            const clone = card.cloneNode(true);
            clone.classList.add('skill-card-clone');
            this.skillsTrack.appendChild(clone);
        });
    }
    
    setupAnimation() {
        // Añadir clase para animación
        this.skillsTrack.classList.add('infinite-scroll');
        
        // Calcular velocidad de animación
        this.updateAnimationSpeed();
        
        // Pausar animación al hacer hover
        this.skillsContainer?.addEventListener('mouseenter', () => {
            this.skillsTrack.style.animationPlayState = 'paused';
        });
        
        this.skillsContainer?.addEventListener('mouseleave', () => {
            this.skillsTrack.style.animationPlayState = 'running';
        });
    }
    
    updateAnimationSpeed() {
        if (!this.skillsTrack) return;
        
        const cardCount = this.skillCards.length;
        const animationDuration = cardCount * 3; // 3 segundos por tarjeta
        
        // Aplicar duración de animación
        this.skillsTrack.style.animationDuration = `${animationDuration}s`;
    }
    
    setupCardInteractions() {
        const allCards = document.querySelectorAll('.skill-card');
        
        allCards.forEach(card => {
            // Agregar indicador visual de que es clickeable
            card.style.cursor = 'pointer';
            
            // Evento de clic para interacción
            card.addEventListener('click', (e) => {
                e.preventDefault();
                this.handleCardClick(card);
            });
            
            // Mejorar accesibilidad
            card.setAttribute('tabindex', '0');
            card.setAttribute('role', 'button');
            
            // Permitir activar con tecla Enter o Space
            card.addEventListener('keydown', (e) => {
                if (e.key === 'Enter' || e.key === ' ') {
                    e.preventDefault();
                    this.handleCardClick(card);
                }
            });
        });
    }
    
    handleCardClick(card) {
        // Remover resaltado previo
        document.querySelectorAll('.skill-card').forEach(c => {
            c.classList.remove('card-active');
        });
        
        // Resaltar tarjeta clickeada
        card.classList.add('card-active');
        
        // Obtener título y descripción de la tarjeta
        const title = card.querySelector('h4')?.textContent || 'Habilidad';
        const description = card.querySelector('p')?.textContent || '';
        
        // Mostrar notificación
        this.showSkillNotification(title, description);
        
        // Remover resaltado después de 2 segundos
        setTimeout(() => {
            card.classList.remove('card-active');
        }, 2000);
    }
    
    showSkillNotification(title, description) {
        // Crear elemento de notificación
        const notification = document.createElement('div');
        notification.className = 'skill-notification';
        notification.innerHTML = `
            <strong>${title}</strong>
            <p>${description}</p>
        `;
        
        // Estilos
        notification.style.cssText = `
            position: fixed;
            top: 20px;
            right: 20px;
            padding: 1rem 1.5rem;
            background: linear-gradient(90deg, #0b74ff, #3b82f6);
            color: white;
            border-radius: 0.5rem;
            font-weight: 500;
            z-index: 10000;
            animation: slideIn 0.3s ease;
            max-width: 300px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.2);
        `;
        
        document.body.appendChild(notification);
        
        // Eliminar después de 3 segundos
        setTimeout(() => {
            notification.style.animation = 'slideOut 0.3s ease forwards';
            setTimeout(() => notification.remove(), 300);
        }, 3000);
    }
}

// ===== MODALES DE PROYECTOS =====
class ProjectModals {
    constructor() {
        this.modals = document.querySelectorAll('.project-modal');
        this.detailButtons = document.querySelectorAll('.project-detail-btn');
        this.currentModal = null;
        
        this.init();
    }
    
    init() {
        this.setupEventListeners();
        this.setupAccessibility();
    }
    
    setupEventListeners() {
        // Botones de detalles
        this.detailButtons.forEach(button => {
            button.addEventListener('click', (e) => {
                e.preventDefault();
                const projectId = button.getAttribute('data-project');
                this.openModal(projectId);
            });
        });
        
        // Botones de cerrar
        this.modals.forEach(modal => {
            const closeBtn = modal.querySelector('.modal-close');
            if (closeBtn) {
                closeBtn.addEventListener('click', () => this.closeModal(modal));
            }
            
            // Cerrar al hacer clic fuera
            modal.addEventListener('click', (e) => {
                if (e.target === modal) {
                    this.closeModal(modal);
                }
            });
        });
        
        // Cerrar con Escape
        document.addEventListener('keydown', (e) => {
            if (e.key === 'Escape' && this.currentModal) {
                this.closeModal(this.currentModal);
            }
        });
    }
    
    setupAccessibility() {
        this.detailButtons.forEach((button, index) => {
            button.setAttribute('aria-label', `Ver detalles del proyecto ${index + 1}`);
        });
    }
    
    openModal(projectId) {
        const modal = document.getElementById(`modal-${projectId}`);
        if (!modal) return;
        
        // Cerrar modal actual si existe
        if (this.currentModal) {
            this.closeModal(this.currentModal);
        }
        
        // Abrir nuevo modal
        modal.classList.add('active');
        document.body.style.overflow = 'hidden';
        this.currentModal = modal;
        
        // Enfocar el botón de cerrar para accesibilidad
        setTimeout(() => {
            const closeBtn = modal.querySelector('.modal-close');
            closeBtn?.focus();
        }, 100);
    }
    
    closeModal(modal) {
        modal.classList.remove('active');
        document.body.style.overflow = '';
        this.currentModal = null;
    }
}

// ===== FORMULARIO DE CONTACTO =====
class ContactForm {
    constructor() {
        this.form = document.getElementById('contact-form');
        if (!this.form) return;
        
        this.submitBtn = this.form.querySelector('button[type="submit"]');
        this.originalBtnText = this.submitBtn?.textContent;
        
        this.init();
    }
    
    init() {
        this.setupEventListeners();
        this.setupValidation();
    }
    
    setupEventListeners() {
        this.form.addEventListener('submit', (e) => this.handleSubmit(e));
    }
    
    setupValidation() {
        const inputs = this.form.querySelectorAll('input, textarea');
        
        inputs.forEach(input => {
            input.addEventListener('input', () => {
                this.validateField(input);
            });
            
            input.addEventListener('blur', () => {
                this.validateField(input);
            });
        });
    }
    
    validateField(field) {
        const value = field.value.trim();
        let isValid = true;
        let errorMessage = '';
        
        if (field.required && !value) {
            isValid = false;
            errorMessage = 'Este campo es obligatorio';
        } else if (field.type === 'email' && value) {
            const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
            if (!emailRegex.test(value)) {
                isValid = false;
                errorMessage = 'Por favor, introduce un email válido';
            }
        }
        
        this.updateFieldState(field, isValid, errorMessage);
        return isValid;
    }
    
    updateFieldState(field, isValid, errorMessage) {
        field.classList.toggle('error', !isValid);
        field.classList.toggle('valid', isValid && field.value.trim() !== '');
        
        // Remover mensaje de error anterior
        let errorElement = field.parentNode.querySelector('.error-message');
        if (errorElement) {
            errorElement.remove();
        }
        
        // Añadir nuevo mensaje de error si es necesario
        if (!isValid && errorMessage) {
            errorElement = document.createElement('span');
            errorElement.className = 'error-message';
            errorElement.textContent = errorMessage;
            errorElement.style.cssText = `
                display: block;
                color: #ef4444;
                font-size: 0.875rem;
                margin-top: 0.25rem;
            `;
            field.parentNode.appendChild(errorElement);
        }
    }
    
    validateForm() {
        const fields = this.form.querySelectorAll('input, textarea');
        let isValid = true;
        
        fields.forEach(field => {
            if (!this.validateField(field)) {
                isValid = false;
            }
        });
        
        return isValid;
    }
    
    async handleSubmit(e) {
        e.preventDefault();
        
        if (!this.validateForm()) {
            this.showNotification('Por favor, corrige los errores del formulario', 'error');
            return;
        }
        
        // Simular envío
        if (this.submitBtn) {
            this.submitBtn.textContent = 'Enviando...';
            this.submitBtn.disabled = true;
            this.submitBtn.classList.add('loading');
        }
        
        try {
            // Simular delay de red
            await new Promise(resolve => setTimeout(resolve, 1500));
            
            // Éxito
            this.showNotification('¡Mensaje enviado con éxito! Te responderé pronto.', 'success');
            this.form.reset();
            
            // Resetear estados de validación
            const fields = this.form.querySelectorAll('input, textarea');
            fields.forEach(field => {
                field.classList.remove('valid', 'error');
                const errorElement = field.parentNode.querySelector('.error-message');
                if (errorElement) errorElement.remove();
            });
            
        } catch (error) {
            this.showNotification('Hubo un error al enviar el mensaje. Por favor, intenta nuevamente.', 'error');
        } finally {
            if (this.submitBtn) {
                this.submitBtn.textContent = this.originalBtnText;
                this.submitBtn.disabled = false;
                this.submitBtn.classList.remove('loading');
            }
        }
    }
    
    showNotification(message, type) {
        // Crear elemento de notificación
        const notification = document.createElement('div');
        notification.className = `notification ${type}`;
        notification.textContent = message;
        notification.setAttribute('role', 'alert');
        
        // Estilos
        notification.style.cssText = `
            position: fixed;
            top: 20px;
            right: 20px;
            padding: 1rem 1.5rem;
            border-radius: 0.5rem;
            color: white;
            font-weight: 500;
            z-index: 10000;
            animation: slideIn 0.3s ease;
            max-width: 350px;
            box-shadow: 0 10px 25px rgba(0, 0, 0, 0.2);
        `;
        
        if (type === 'success') {
            notification.style.background = 'linear-gradient(90deg, #10b981, #059669)';
        } else {
            notification.style.background = 'linear-gradient(90deg, #ef4444, #dc2626)';
        }
        
        document.body.appendChild(notification);
        
        // Eliminar después de 5 segundos
        setTimeout(() => {
            notification.style.animation = 'slideOut 0.3s ease forwards';
            setTimeout(() => notification.remove(), 300);
        }, 5000);
        
        // Añadir estilos de animación si no existen
        if (!document.querySelector('#notification-styles')) {
            const style = document.createElement('style');
            style.id = 'notification-styles';
            style.textContent = `
                @keyframes slideIn {
                    from {
                        transform: translateX(100%);
                        opacity: 0;
                    }
                    to {
                        transform: translateX(0);
                        opacity: 1;
                    }
                }
                @keyframes slideOut {
                    from {
                        transform: translateX(0);
                        opacity: 1;
                    }
                    to {
                        transform: translateX(100%);
                        opacity: 0;
                    }
                }
            `;
            document.head.appendChild(style);
        }
    }
}

// ===== ANIMACIONES AL SCROLL =====
class ScrollAnimations {
    constructor() {
        this.observer = null;
        this.animatedElements = new Set();
        
        this.init();
    }
    
    init() {
        this.createObserver();
        this.observeElements();
        this.setupSmoothScrolling();
    }
    
    createObserver() {
        this.observer = new IntersectionObserver(
            (entries) => {
                entries.forEach(entry => {
                    if (entry.isIntersecting && !this.animatedElements.has(entry.target)) {
                        this.animateElement(entry.target);
                        this.animatedElements.add(entry.target);
                    }
                });
            },
            {
                root: null,
                rootMargin: `${CONFIG.animations.scrollOffset}px`,
                threshold: CONFIG.animations.scrollThreshold
            }
        );
    }
    
    observeElements() {
        const elements = document.querySelectorAll('.project-item, .skill-card, .about-card');
        elements.forEach(element => {
            element.style.opacity = '0';
            element.style.transform = 'translateY(20px)';
            this.observer.observe(element);
        });
    }
    
    animateElement(element) {
        element.classList.add('animate-in');
        
        // Remover estilos inline después de la animación
        setTimeout(() => {
            element.style.opacity = '';
            element.style.transform = '';
        }, 600);
    }
    
    setupSmoothScrolling() {
        // Navegación suave para enlaces internos
        document.querySelectorAll('a[href^="#"]').forEach(anchor => {
            anchor.addEventListener('click', function(e) {
                const href = this.getAttribute('href');
                if (href === '#' || href === '#!') return;
                
                const targetElement = document.querySelector(href);
                if (targetElement) {
                    e.preventDefault();
                    
                    const headerOffset = document.querySelector('.header')?.offsetHeight || 80;
                    const elementPosition = targetElement.getBoundingClientRect().top;
                    const offsetPosition = elementPosition + window.pageYOffset - headerOffset;
                    
                    window.scrollTo({
                        top: offsetPosition,
                        behavior: 'smooth'
                    });
                    
                    // Cerrar menú móvil si está abierto
                    const mobileNav = document.querySelector('.main-nav');
                    if (mobileNav?.classList.contains('open')) {
                        mobileNav.classList.remove('open');
                        document.querySelector('.menu-btn')?.setAttribute('aria-expanded', 'false');
                    }
                }
            });
        });
    }
}

// ===== INICIALIZACIÓN =====
document.addEventListener('DOMContentLoaded', () => {
    // Inicializar componentes
    const mobileNav = new MobileNavigation();
    const navigationObserver = new NavigationObserver();
    const infiniteScrollSkills = new InfiniteScrollSkills(); // Nueva clase
    const projectModals = new ProjectModals();
    const contactForm = new ContactForm();
    const scrollAnimations = new ScrollAnimations();
    
    // Verificar elementos (para debugging)
    console.log('Inicializando Portfolio...');
    console.log('Secciones encontradas:', document.querySelectorAll('section[id]').length);
    console.log('Enlaces de navegación:', document.querySelectorAll('.main-nav a').length);
    
    // Actualizar año en el footer
    const yearElement = document.getElementById('current-year');
    if (yearElement) {
        yearElement.textContent = new Date().getFullYear();
    }
    
    // Efecto de parallax en hero
    window.addEventListener('scroll', () => {
        const scrolled = window.pageYOffset;
        const heroSection = document.querySelector('#about');
        
        const rate = scrolled * -0.1;
        if (heroSection) {
            const rate = scrolled * -0.1;
            heroSection.style.transform = `translateY(${rate}px)`;
        }
    });
    
    // Log de inicialización
    console.log('✅ Portfolio cargado correctamente');
});

// ===== POLYFILLS PARA FUNCIONALIDADES MÁS ANTIGUAS =====
// Intersection Observer polyfill si es necesario
if (!('IntersectionObserver' in window) ||
    !('IntersectionObserverEntry' in window) ||
    !('intersectionRatio' in window.IntersectionObserverEntry.prototype)) {
    
    console.log('Cargando polyfill para Intersection Observer...');
    
    // Cargar polyfill dinámicamente
    const script = document.createElement('script');
    script.src = 'https://polyfill.io/v3/polyfill.min.js?features=IntersectionObserver';
    document.head.appendChild(script);
}

// Smooth Scroll polyfill si es necesario
if (!('scrollBehavior' in document.documentElement.style)) {
    console.log('Cargando polyfill para Smooth Scroll...');
    const script = document.createElement('script');
    script.src = 'https://cdn.jsdelivr.net/npm/smoothscroll-polyfill@0.4.4/dist/smoothscroll.min.js';
    document.head.appendChild(script);
    script.onload = () => {
        window.__forceSmoothScrollPolyfill__ = true;
        smoothscroll.polyfill();
    };
}

