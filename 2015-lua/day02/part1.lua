package.path = package.path .. ';../utils/fileUtils.lua'
local FileUtils = require 'fileUtils.lua'

content = FileUtils.getInput()

local sum = 0

for line in string.gmatch(content, "[^\r\n]+") do
    for length, width, height in string.gmatch(line, "(%d+)x(%d+)x(%d+)") do
        local surfaceArea = 2 * (length * width + width * height + height * length)
        local extra = math.min(length * width, width * height, height * length);

        sum = sum + surfaceArea + extra
    end
end

print('sum:', sum)