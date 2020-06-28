CREATE TABLE map (
    id INT NOT NULL AUTO_INCREMENT,
    hash VARCHAR(1000) NOT NULL,
    name VARCHAR(200) NOT NULL,
    description VARCHAR(4000),
    author VARCHAR(200),
    players INT,
    width INT,
    height INT,
    base64_rules TEXT,
    base64_players TEXT,
    downloadable boolean,
    official boolean,
    obsoleted boolean,
    last_played DATETIME,
    last_uploaded DATETIME,
    last_downloaded DATETIME,
    CONSTRAINT PRIMARY KEY (id)
);

CREATE TABLE `mod` (
    id INT NOT NULL AUTO_INCREMENT,
    name VARCHAR(200) NOT NULL,
    author VARCHAR(200),
    CONSTRAINT PRIMARY KEY (id)
);

CREATE TABLE mod_version (
    id INT NOT NULL AUTO_INCREMENT,
    mod_id INT NOT NULL,
    version VARCHAR(200),
    CONSTRAINT PRIMARY KEY (id),
    CONSTRAINT mod_version_mod_fk FOREIGN KEY (mod_id) REFERENCES `mod` (id)
);

CREATE TABLE map_compatibility (
    id INT NOT NULL AUTO_INCREMENT,
    map_id INT NOT NULL,
    mod_version_id INT NOT NULL,
    compatible boolean,
    lint_logs TEXT,
    CONSTRAINT PRIMARY KEY (id),
    CONSTRAINT map_compatibility_map_fk FOREIGN KEY (map_id) REFERENCES map (id),
    CONSTRAINT map_compatibility_mod_version_fk FOREIGN KEY (mod_version_id) REFERENCES mod_version (id)
);

CREATE TABLE `user` (
    id INT NOT NULL AUTO_INCREMENT,
    object_id VARCHAR(200) NOT NULL,
    CONSTRAINT PRIMARY KEY (id)
);

CREATE TABLE user_collection (
    id INT NOT NULL AUTO_INCREMENT,
    user_id INT NOT NULL,
    name VARCHAR(200),
    CONSTRAINT PRIMARY KEY (id),
    CONSTRAINT user_collection_user_fk FOREIGN KEY (user_id) REFERENCES `user` (id)
);

CREATE TABLE collection_map_link (
    id INT NOT NULL AUTO_INCREMENT,
    user_collection_id INT NOT NULL,
    map_id INT NOT NULL,
    CONSTRAINT PRIMARY KEY (id),
    CONSTRAINT collection_map_link_user_collection_fk FOREIGN KEY (user_collection_id) REFERENCES user_collection (id),
    CONSTRAINT collection_map_link_map_fk FOREIGN KEY (map_id) REFERENCES map (id)
);

CREATE TABLE entity_metadata (
    id INT NOT NULL AUTO_INCREMENT,
    entity_type INT NOT NULL,
    entity_id INT NOT NULL,
    `key` VARCHAR(200),
    `value` VARCHAR(200),
    CONSTRAINT PRIMARY KEY (id)
);