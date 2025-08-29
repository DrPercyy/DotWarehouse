-- ============================
-- Units
-- ============================
CREATE TABLE units (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    abbreviation VARCHAR(50) NOT NULL,
    create_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    update_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- ============================
-- Categories
-- ============================
CREATE TABLE categories (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    create_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    update_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- ============================
-- Products
-- ============================
CREATE TABLE products (
    id INT PRIMARY KEY AUTO_INCREMENT,
    name VARCHAR(255) NOT NULL,
    description TEXT,
    img BLOB,
    sale_price INT NOT NULL, -- in cents
    barcode VARCHAR(255) NOT NULL,
    unit_id INT NOT NULL,
    category_id INT NOT NULL,
    is_active BOOLEAN NOT NULL DEFAULT TRUE,
    create_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    update_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (unit_id) REFERENCES units(id),
    FOREIGN KEY (category_id) REFERENCES categories(id)
);

-- ============================
-- Movements
-- ============================
CREATE TABLE movements (
    id INT PRIMARY KEY AUTO_INCREMENT,
    product_id INT NOT NULL,
    quantity INT NOT NULL,
    movement_type VARCHAR(10) NOT NULL, -- e.g., IN or OUT
    note TEXT,
    create_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    update_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (product_id) REFERENCES products(id)
);

-- ============================
-- Suppliers
-- ============================
CREATE TABLE suppliers (
    id INT PRIMARY KEY AUTO_INCREMENT,
    legal_name VARCHAR(255) NOT NULL,
    trade_name VARCHAR(255),
    tax_id VARCHAR(20) UNIQUE NOT NULL,
    phone VARCHAR(20),
    email VARCHAR(255),
    Saddress TEXT,
    active BOOLEAN NOT NULL DEFAULT TRUE,
    create_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    update_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP
);

-- ============================
-- Products_Suppliers (Many-to-Many)
-- ============================
CREATE TABLE products_suppliers (
    id INT PRIMARY KEY AUTO_INCREMENT,
    product_id INT NOT NULL,
    supplier_id INT NOT NULL,
    supplier_price INT, -- in cents
    delivery_time_days INT,
    create_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    update_date TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    FOREIGN KEY (product_id) REFERENCES products(id),
    FOREIGN KEY (supplier_id) REFERENCES suppliers(id)
);
