-- Open the file for reading
local file = io.open('input.txt', 'r')
if not file then
    error("Failed to open file")
end

-- Read the entire content of the file
local content = file:read('*a')

-- Close the file
file:close()

local sum = 0

for line in string.gmatch(content, "[^\r\n]+") do
    for length, width, height in string.gmatch(line, "(%d+)x(%d+)x(%d+)") do
        local volume = length * width * height
         
        local perimeter1 = 2 * (length + width) 
        local perimeter2 = 2 * (width + height)
        local perimeter3 = 2 * (height + length)
        
        ribbon = math.min(perimeter1, perimeter2, perimeter3)       

        sum = sum + ribbon + volume
    end
end

print('sum:', sum)