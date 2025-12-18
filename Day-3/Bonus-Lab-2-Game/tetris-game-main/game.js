class Block {
    constructor(game) {
        this.game = game;
        this.rotation = 0;
        this.anchor = [];
        this.is_active = false;
        this.position = [];
        this.ACTIVE_BLOCK = 1;
        this.BLOCK_CLASSES = ["block", "block-T", "block-I", "block-L", "block-L2", "block-Z", "block-Z2", "block-O"]
        this.BLOCK_TYPES = ["T", "L", "L2", "I", "Z", "Z2", "O"];
        this.BLOCK_INFO = {
            "T": {
                "shape": [
                    [
                        [0,1,0],
                        [1,1,1],
                        [0,0,0]
                    ],
                    [
                        [0,1,0],
                        [0,1,1],
                        [0,1,0]
                    ],
                    [
                        [0,0,0],
                        [1,1,1],
                        [0,1,0]
                    ],
                    [
                        [0,1,0],
                        [1,1,0],
                        [0,1,0]
                    ]
                ]
            },
            "L": {
                "shape": [
                    [
                        [0,0,1],
                        [1,1,1],
                        [0,0,0]
                    ],
                    [
                        [0,1,0],
                        [0,1,0],
                        [0,1,1]
                    ],
                    [
                        [0,0,0],
                        [1,1,1],
                        [1,0,0]
                    ],
                    [
                        [1,1,0],
                        [0,1,0],
                        [0,1,0]
                    ]
                ]
            },
            "L2": {
                "shape": [
                    [
                        [1,0,0],
                        [1,1,1],
                        [0,0,0]
                    ],
                    [
                        [0,1,1],
                        [0,1,0],
                        [0,1,0]
                    ],
                    [
                        [0,0,0],
                        [1,1,1],
                        [0,0,1]
                    ],
                    [
                        [0,1,0],
                        [0,1,0],
                        [1,1,0]
                    ]
                ]
            },
            "I": {
                "shape": [
                    [
                        [0,0,0,0],
                        [1,1,1,1],
                        [0,0,0,0],
                        [0,0,0,0]
                    ],
                    [
                        [0,0,1,0],
                        [0,0,1,0],
                        [0,0,1,0],
                        [0,0,1,0]
                    ],
                    [
                        [0,0,0,0],
                        [0,0,0,0],
                        [1,1,1,1],
                        [0,0,0,0]
                    ],
                    [
                        [0,1,0,0],
                        [0,1,0,0],
                        [0,1,0,0],
                        [0,1,0,0]
                    ],
                ]
            },
            "Z": {
                "shape": [
                    [
                        [1,1,0],
                        [0,1,1],
                        [0,0,0]
                    ],
                    [
                        [0,0,1],
                        [0,1,1],
                        [0,1,0]
                    ],
                    [
                        [0,0,0],
                        [1,1,0],
                        [0,1,1]
                    ],
                    [
                        [0,1,0],
                        [1,1,0],
                        [1,0,0]
                    ]
                ]
            },
            "Z2": {
                "shape": [
                    [
                        [0,1,1],
                        [1,1,0],
                        [0,0,0]
                    ],
                    [
                        [0,1,0],
                        [0,1,1],
                        [0,0,1]
                    ],
                    [
                        [0,0,0],
                        [0,1,1],
                        [1,1,0]
                    ],
                    [
                        [1,0,0],
                        [1,1,0],
                        [0,1,0]
                    ]
                ]
            },
            "O": {
                "shape": [
                    [
                        [1,1],
                        [1,1]
                    ],
                    [
                        [1,1],
                        [1,1]
                    ],
                    [
                        [1,1],
                        [1,1]
                    ],
                    [
                        [1,1],
                        [1,1]
                    ]
                ]
            }
        };
        // this.selected_block_shape = "Z";
        this.selected_block_shape = this.BLOCK_TYPES[Math.floor(Math.random() * this.BLOCK_TYPES.length)];
    }
    spawn() {
        this.is_active = true;
        let blockInfo = this.BLOCK_INFO[this.selected_block_shape].shape[this.rotation];
        let boardX = Math.floor(this.game.width/2);
        let blockX = Math.floor(blockInfo[0].length/2);
        let startingX = boardX - blockX;
        this.anchor = [startingX,1];
        for(let line = 0; line < blockInfo.length; line++) {
            for(let cell = 0; cell < blockInfo[line].length; cell++) {
                if(blockInfo[line][cell] == this.ACTIVE_BLOCK) {
                    this.position.push([this.anchor[0] + cell, this.anchor[1] + line]);
                }
            }
        }
        this.render();
    }
    setInactive() {
        this.is_active = false;
        this.game.container.querySelectorAll(".active-block").forEach(cell => {
            cell.classList.remove("active-block");
        });
        this.game.checkLines();
    }
    render() {
        for(let p = 0; p < this.position.length; p++) {
            if(this.position[p] == null) continue;
            var block = this.game.container.querySelector(`.cell[data-position="${this.position[p][0]},${this.position[p][1]}"]`);
            // block.setAttribute("data-block", true);
            block.classList.add("block", `block-${this.selected_block_shape}`, "active-block")   
        }
    }
    clearBlock() {
        document.querySelectorAll(".cell.active-block").forEach(el => {
            el.classList.remove(...this.BLOCK_CLASSES);
            // el.setAttribute("data-block", false);
        });
    }
    rotateClockwise() {
        this.rotation++;
        if(this.rotation == this.BLOCK_INFO[this.selected_block_shape].shape.length)
            this.rotation = 0;
        let blockInfo = this.BLOCK_INFO[this.selected_block_shape].shape[this.rotation];
        this.clearBlock();
        this.position = [];
        for(let line = 0; line < blockInfo.length; line++) {
            for(let cell = 0; cell < blockInfo[line].length; cell++) {
                if(blockInfo[line][cell] == this.ACTIVE_BLOCK) {
                    this.position.push([this.anchor[0] + cell, this.anchor[1] + line]);
                }
            }
        }
        this.render();
    }
    rotateCounterClockwise() {
        this.rotation--;
        if(this.rotation == -1)
            this.rotation = this.BLOCK_INFO[this.selected_block_shape].shape.length - 1;
        let blockInfo = this.BLOCK_INFO[this.selected_block_shape].shape[this.rotation];
        this.clearBlock();
        this.position = [];
        for(let line = 0; line < blockInfo.length; line++) {
            for(let cell = 0; cell < blockInfo[line].length; cell++) {
                if(blockInfo[line][cell] == this.ACTIVE_BLOCK) {
                    this.position.push([this.anchor[0] + cell, this.anchor[1] + line]);
                }
            }
        }
        this.render();
    }
    moveLeft() {
        for(let p = 0; p < this.position.length; p++) {
            if(this.position[p] == null) continue;
            var blockLeft = this.game.container.querySelector(`.cell[data-position="${this.position[p][0]-1},${this.position[p][1]}"`);
            if(this.position[p][0] == 1 ||
                (blockLeft.classList.value.split(" ").indexOf("block") >= 0 && 
                blockLeft.classList.value.split(" ").indexOf("active-block") == -1)
            ) return;
        }
        this.anchor[0]--;
        this.clearBlock();
        for(let p = 0; p < this.position.length; p++) {
            if(this.position[p] == null) continue;
            this.position[p][0]--;
        }
        this.render();
    }
    moveRight() {
        for(let p = 0; p < this.position.length; p++) {
            if(this.position[p] == null) continue;
            var blockRight = this.game.container.querySelector(`.cell[data-position="${this.position[p][0]+1},${this.position[p][1]}"`);
            if(this.position[p][0] == this.game.width ||
                (blockRight.classList.value.split(" ").indexOf("block") >= 0 && 
                blockRight.classList.value.split(" ").indexOf("active-block") == -1)
            ) return;
        }
        this.anchor[0]++;
        this.clearBlock();
        for(let p = 0; p < this.position.length; p++) {
            if(this.position[p] == null) continue;
            this.position[p][0]++;
        }
        this.render();
    }
    moveDown() {
        for(let p = 0; p < this.position.length; p++) {
            if(this.position[p] == null) continue;
            var blockBelow = this.game.container.querySelector(`.cell[data-position="${this.position[p][0]},${this.position[p][1]+1}"`);
            if(this.position[p][1] == this.game.height || 
                (blockBelow.classList.value.split(" ").indexOf("block") >= 0 &&
                blockBelow.classList.value.split(" ").indexOf("active-block") == -1)
                ) {
                this.setInactive();
                return;
            }
        }
        this.anchor[1]++;
        this.clearBlock();
        for(let p = 0; p < this.position.length; p++) {
            if(this.position[p] == null) continue;
            this.position[p][1]++;
        }
        this.render();
    }
}


class TetrisGame {
    constructor(container) {
        this.container = container;
        this.interval = null;
        this.speed = 1000;
        this.width = 10;
        this.height = 20;
        this.active_block = null;
        this.render();
        this.start();
        
        document.onkeydown = event => {
            switch(event.key) {
                case "a":
                case "ArrowLeft":
                    this.active_block.moveLeft();
                    break;
                case "d":
                case "ArrowRight":
                    this.active_block.moveRight();
                    break;
                case "s":
                case "ArrowDown":
                    this.active_block.moveDown();
                    break;
                case "o":
                    this.active_block.rotateCounterClockwise();
                    break;
                case "p":
                    this.active_block.rotateClockwise();
                    break;
            }
        }
    }
    clearLine(rows) {
        let that = this;
        rows.forEach(row => {
            row.querySelectorAll(".cell").forEach(cell => {
                cell.classList.remove(...that.active_block.BLOCK_CLASSES);
            });
        });
        rows = this.container.querySelectorAll(".row:not(.border)");
        var clearedLines = 0;
        for(var i = rows.length - 1; i >= 0; i--) {
            let row = rows[i];
            let isCleared = true;
            row.querySelectorAll(".cell:not(.border)").forEach(cell => {
                if(cell.classList.value.split(" ").indexOf("block") >= 0)
                    isCleared = false;
            });
            if(isCleared) {
                clearedLines++;
            } else {
                row.querySelectorAll(".cell:not(.border)").forEach(cell => {
                    let position = cell.getAttribute("data-position").split(",");
                    let x = parseInt(position[0]);
                    let y = parseInt(position[1]) + clearedLines;
                    that.container.querySelector(`.cell[data-position="${x},${y}"]`).classList = cell.classList;
                    cell.classList.remove(...this.active_block.BLOCK_CLASSES);
                });
            }

        }
    }
    checkLines() {
        let rows = [];
        this.container.querySelectorAll(".row:not(.border)").forEach(row => {
            let isCleared = true;
            row.querySelectorAll(".cell:not(.border)").forEach(cell => {
                if(cell.classList.value.split(" ").indexOf("block") == -1)
                    isCleared = false;
            });
            if(isCleared) {
                rows.push(row);
            }
        });
        if(rows.length != 0) this.clearLine(rows);
    }
    start() {
        this.active_block = new Block(this);
        this.active_block.spawn();
        this.interval = setInterval(async () => {
            this.active_block.moveDown();
            
            if(!this.active_block.is_active) {
                this.active_block = new Block(this);
                this.active_block.spawn();
            }
        }, this.speed);
    }
    render() {
        this.insertHorizontalBorder();
        for(let h = 0; h < this.height; h++) {
            let row = document.createElement("div");
            row.classList.add("row");
            let borderCellLeft = document.createElement("div");
            borderCellLeft.classList.add("cell", "border");
            row.insertAdjacentElement("beforeend", borderCellLeft);
            for(let w = 0; w < this.width; w++) {
                let cell = document.createElement("div");
                cell.classList.add("cell");
                cell.setAttribute("data-position", `${w+1},${h+1}`);
                row.insertAdjacentElement("beforeend", cell);
            }
            let borderCellRight = document.createElement("div");
            borderCellRight.classList.add("cell", "border");
            row.insertAdjacentElement("beforeend", borderCellRight);

            this.container.insertAdjacentElement("beforeend", row);
        }
        this.insertHorizontalBorder();
    }
    insertHorizontalBorder() {
        let row = document.createElement("div");
        row.classList.add("row", "border");
        for(let i = 0; i < this.width + 2; i++) {
            let cell = document.createElement("div");
            cell.classList.add("cell", "border");
            row.insertAdjacentElement("beforeend", cell);
        }
        this.container.insertAdjacentElement("beforeend", row);
    }
}